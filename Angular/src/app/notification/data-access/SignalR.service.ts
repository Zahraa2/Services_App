import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { from, mergeMap, Observable, Subject } from 'rxjs';
import { CustomerRequest } from './classes/CustomerRequest';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

   public subject:Subject<CustomerRequest> = new Subject<CustomerRequest>();

   connection = new signalR.HubConnectionBuilder()
  .configureLogging(signalR.LogLevel.Debug)
  .withUrl("/notify", {
    skipNegotiation: true,
    transport: signalR.HttpTransportType.WebSockets,
  })
  .build();
  private readonly startedConntion = this.startConnection()

  //bulid hubconnection
  constructor() {

  }


  //on function to handel recived request
  on(method: string):Observable<CustomerRequest> {
    this.connection.on(method, (data: any) => {
      return this.subject.next(data);
    })
    return this.subject.asObservable();
  }


  invoke(method: string, ...data: any): Observable<any> {
    return from(this.startedConntion)
      .pipe(
        mergeMap(_ => {
          return this.connection.invoke(method, ...data)
        })
      )
  }



  startConnection() {
    return this.connection.start().then(() => {
        console.log("Hub Connection Start");
        return "Connected"
      })
    // .catch(err => {
    //   console.log('Error while establishing connection, retrying...');
    //   setTimeout(this.startConnection, 5000)
    // })
  }

}
