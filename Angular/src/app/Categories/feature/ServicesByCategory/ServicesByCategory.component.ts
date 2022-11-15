import {  Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Service } from '../../data-access/Classes/Service';
import { ourServicese } from '../../data-access/Services.service';

@Component({
  selector: 'app-ServicesByCategory',
  templateUrl: './ServicesByCategory.component.html',
  styleUrls: ['./ServicesByCategory.component.css'],

})


export class ServicesByCategoryComponent implements OnInit , OnChanges{

  id:string =  ''

  searchText:any
  active:number = 1
  size:number = 5
  totalNumber:number | any
  seleted:Service[] = [] 
  constructor(public selectedService:ourServicese , public activeRouter:ActivatedRoute) { }

  ngOnChanges(changes: SimpleChanges): void {

  }

  ngOnInit() {
    this.id = this.activeRouter.snapshot.params['id']
    this.seleted = this.selectedService.getSelectedServices(this.id)
    this.totalNumber = this.selectedService.getSelectedServices(this.id).length
  }

}
