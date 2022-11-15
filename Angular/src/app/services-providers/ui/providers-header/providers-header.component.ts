import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-providers-header',
  templateUrl: './providers-header.component.html',
  styleUrls: ['./providers-header.component.css']
})
export class ProvidersHeaderComponent implements OnInit {

  constructor() { }

  windowScrolled = false;

  ngOnInit() {
    window.addEventListener('scroll', () => {
      if(window.pageYOffset>100){
        this.windowScrolled=true
      }
      else{
        this.windowScrolled=false
      }
    });
  }

}
