import { Component, OnInit } from '@angular/core';
import { service } from '../Models/serivce';
import { MostPopularService } from '../services/MostPopular.service';
import { OwlOptions } from 'ngx-owl-carousel-o';


@Component({
  selector: 'app-MostPopular',
  templateUrl: './MostPopular.component.html',
  styleUrls: ['./MostPopular.component.css']
})


export class MostPopularComponent implements OnInit {

  constructor(private servies:MostPopularService) { }

  mostPopularService:service[] =[]
  ngOnInit() {
    this.onFetchServices();
  }
    
  onFetchServices(){
    this.servies.fetchServices().subscribe(services => {
      this.mostPopularService = services;
      
    });
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


