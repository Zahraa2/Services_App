import { Component, OnInit } from '@angular/core';
import { MostPopularService } from '../../data-access/MostPopular.service';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { Service } from '../../data-access/Classes/Service';


@Component({
  selector: 'app-MostPopular',
  templateUrl: './MostPopular.component.html',
  styleUrls: ['./MostPopular.component.css'],
})


export class MostPopularComponent implements OnInit {

  constructor(private servies:MostPopularService) { }
  mostPopularService:Service[] =[]
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


