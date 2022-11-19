import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Service } from './Classes/Service';

@Injectable({
  providedIn: 'root'
})
export class MostPopularService {

  constructor(public http: HttpClient) { }
  lang:string =localStorage.getItem('lang')||'en';
  fetchServices (){
    return this.http.get<Service[]>(`https://localhost:7142/api/Services/MostPopular?culture=${this.lang}`);
  }
}
