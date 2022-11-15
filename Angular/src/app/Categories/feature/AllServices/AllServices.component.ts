import {  Component, OnInit } from '@angular/core';
import { Service } from '../../data-access/Classes/Service';
import { ourServicese } from '../../data-access/Services.service';

@Component({
  selector: 'app-AllServices',
  templateUrl: './AllServices.component.html',
  styleUrls: ['./AllServices.component.css'],

})
export class AllServicesComponent implements OnInit {

  searchText:any
  active:number = 1
  size:number = 5
  totalNumber:number | any
  seleted:Service[] = [] 
  constructor(public selectedService:ourServicese) { }

  ngOnInit() {
    this.seleted = this.selectedService.getAllServiecs()
    this.totalNumber = this.selectedService.getAllServiecs().length
  }

}
