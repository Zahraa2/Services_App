import {  Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { error } from 'jquery';
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
  constructor(public selectedService:ourServicese , public activeRouter:ActivatedRoute , public route:Router) { }

  ngOnChanges(changes: SimpleChanges): void {

  }

  ngOnInit() {
  
    this.activeRouter.params.subscribe(a => {
      this.id = a['id']
      this.selectedService.getSelectedServices(this.id).subscribe(a =>{
        this.seleted = a
      } , error => {
        this.route.navigateByUrl('/')
      })
    })
  }

}
