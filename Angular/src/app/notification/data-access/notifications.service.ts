import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLogged } from 'src/app/Profile/data-access/Classes/UserLogged';
import { CustomerRequest } from './classes/CustomerRequest';


@Injectable({
  providedIn: 'root'
})
export class NotificationsService {
  Header = new HttpHeaders({ 'Content-Type': 'application/json' });
  postId:string = ''
  public flag:boolean|any;
  public id:string |any
  constructor(public http: HttpClient) { }

  CustomerRequest(data: any) {
    return this.http.post("https://localhost:7142/api/Request/CustomerSendRequest/", data, { headers: this.Header })
  }


  ProviderRequest(data: any) {
    return this.http.post("https://localhost:7142/api/Request/ProviderSendOffer", data, { headers: this.Header })
  }

 
  ProviderRejectedRequest(data: any) {
    return this.http.post("https://localhost:7142/api/Request/ProviderRejectRequest", data, { headers: this.Header })
  }

   
  CustomerRejectedRequest(data: any) {
    return this.http.post("https://localhost:7142/api/Request/CustomerRejectOffer", data, { headers: this.Header })
  }

  CustomerAcceptedRequest(data: any) {
    return this.http.post("https://localhost:7142/api/Request/CustomerAcceptOffer", data, { headers: this.Header })
  }


  //get all customer notifcation

  getAllCustomerNotification(id:string):Observable<CustomerRequest[]>{
   return this.http.get<CustomerRequest[]>(`https://localhost:7142/api/Request/CustomerAllRequest/${id}` )
  }

  getAllProviderNotification(id:string):Observable<CustomerRequest[]>{
   return this.http.get<CustomerRequest[]>(`https://localhost:7142/api/Request/ProviderAllRequest/${id}`)
  }

  getNotificationsDetails(id:string):Observable<CustomerRequest>{
    return this.http.get<CustomerRequest>(`https://localhost:7142/api/Request/GetRequest/${id}`)
  }


  //setter getter post id

  setPostId(id:string){
    this.postId = id
  }
  getPostId(){
    return this.postId
  }

}
