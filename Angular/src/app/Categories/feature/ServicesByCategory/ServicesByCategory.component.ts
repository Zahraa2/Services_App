import {  Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Service } from '../../data-access/Classes/Service';
import { ourServicese } from '../../data-access/Services.service';

@Component({
  selector: 'app-ServicesByCategory',
  templateUrl: './ServicesByCategory.component.html',
  styleUrls: ['./ServicesByCategory.component.css'],

})


export class ServicesByCategoryComponent implements OnInit , OnChanges{

  @Input() paramter:string | any

  searchText:any
  active:number = 1
  size:number = 5
  totalNumber:number | any
  seleted:Service[] = [] 
  constructor(public selectedService:ourServicese) { }

  ngOnChanges(changes: SimpleChanges): void {
    this.seleted = this.selectedService.getSelectedServices(this.paramter)
    this.totalNumber = this.selectedService.getSelectedServices(this.paramter).length
  }

  ngOnInit() {

  }

  onCategoriesChange(categ:string){
    this.paramter = categ
  }

}
