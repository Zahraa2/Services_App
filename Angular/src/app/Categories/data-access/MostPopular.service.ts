import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { service } from './Classes/serivce';

@Injectable({
  providedIn: 'root'
})
export class MostPopularService {

  constructor(public http: HttpClient) { }
  
  fetchServices (){
    return this.http.get<service[]>('http://localhost:3000/MostPopularServices');
  }
}
