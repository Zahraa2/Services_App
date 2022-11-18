import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Service } from './Classes/Service';

@Injectable({
  providedIn: 'root'
})
export class MostPopularService {

  constructor(public http: HttpClient) { }
  
  fetchServices (){
    return this.http.get<Service[]>('https://localhost:7142/api/Services/MostPopular');
  }
}
