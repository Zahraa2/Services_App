import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerRequest } from './classes/CustomerRequest';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {
  Header = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(public http: HttpClient) { }

  CustomerRequest(data: any): Observable<CustomerRequest> {
    return this.http.post<CustomerRequest>("https://localhost:7142/api/Request/CustomerSendRequest", data, { headers: this.Header })
  }

}
