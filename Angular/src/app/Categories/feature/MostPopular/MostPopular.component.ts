import { Component, OnInit } from '@angular/core';
import { MostPopularService } from '../../data-access/MostPopular.service';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { Service } from '../../data-access/Classes/Service';
import { ourServicese } from '../../data-access/Services.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-MostPopular',
  templateUrl: './MostPopular.component.html',
  styleUrls: ['./MostPopular.component.css'],
})


export class MostPopularComponent implements OnInit {

  constructor(private servies:MostPopularService , public selectedService:ourServicese , public route:Router) { }
  mostPopularService:Service[] =[]
  ngOnInit() {
    this.onFetchServices();
  }
    
  onFetchServices(){
    this.servies.fetchServices().subscribe(services => {
      this.mostPopularService = services;
    });
  }
  
  routeTo(serviceName:string){
    this.route.navigateByUrl("services")
    this.selectedService.setProviderServices(serviceName);
  }

  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: true,
    dots: true,
    navSpeed: 750,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      940: {
        items: 3
      }
    },
    nav: false
  }
}


