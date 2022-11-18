import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-RequestDetails',
  templateUrl: './RequestDetails.component.html',
  styleUrls: ['./RequestDetails.component.css']
})
export class RequestDetailsComponent implements OnInit {

  constructor(public route:Router) { }

  ngOnInit() {
  }

  sendRequest(){
    this.route.navigateByUrl("Request/offer")
  }


}
