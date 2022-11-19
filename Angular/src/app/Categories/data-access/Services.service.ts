import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Service } from './Classes/Service';

@Injectable({
  providedIn: 'root'
})


export class ourServicese {
  lang:string =localStorage.getItem('lang')||'en';

  providerService:string = ''
  services: Service[] = [ ]
  constructor(public http:HttpClient , public activeRouter:ActivatedRoute) { }

  getAllServiecs(){
  return this.http.get<Service[]>(`https://localhost:7142/api/Services?culture=${this.lang}`)
}
  getSelectedServices(id:string) {
    return this.http.get<Service[]>("https://localhost:7142/api/Services/ByCatigory/"+id);
  }

  setProviderServices(id:string){
    this.providerService = id
  }
  getProviderServices(){
    return this.providerService
  }

}
