import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Service } from './Classes/Service';

@Injectable({
  providedIn: 'root'
})


export class ourServicese {

  services: Service[] = [ ]
  constructor(public http:HttpClient , public activeRouter:ActivatedRoute) { }

  getAllServiecs(){
  return this.http.get<Service[]>("https://localhost:7142/api/Services")
}


  getSelectedServices(id:string) {
    return this.http.get<Service[]>("https://localhost:7142/api/Services/ByCatigory/"+id);
  }

}
