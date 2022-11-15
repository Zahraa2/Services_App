import {Component, Input, OnInit} from '@angular/core';
import { Service } from '../../data-access/Classes/Service';
import { ourServicese } from '../../data-access/Services.service';

@Component({
  selector: 'app-ServiceSearch',
  templateUrl: './ServiceSearch.component.html',
  styleUrls: ['./ServiceSearch.component.css']
})


export class ServiceSearchComponent implements OnInit {

  options:Service[] = this.allService.getAllServiecs()

  searchText:any
  constructor(public allService:ourServicese){}
  ngOnInit(){}


 
}
