import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerRequest } from './classes/CustomerRequest';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

constructor(public http:HttpClient) { }


 CustomerRequest(data:CustomerRequest){
  return this.http.post("https://localhost:7142/api/Request/CustomerSendRequest" , data);
 }

}
