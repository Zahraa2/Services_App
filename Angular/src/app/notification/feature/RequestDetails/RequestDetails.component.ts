import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerRequest } from '../../data-access/classes/CustomerRequest';
import { NotificationsService } from '../../data-access/notifications.service';

@Component({
  selector: 'app-RequestDetails',
  templateUrl: './RequestDetails.component.html',
  styleUrls: ['./RequestDetails.component.css']
})
export class RequestDetailsComponent implements OnInit {

  notifcation:CustomerRequest | any
  constructor(public route:Router , public notifications:NotificationsService) { }

  ngOnInit() {
    this.notifications.getNotificationsDetails(this.notifications.getPostId()).subscribe( data =>{
      this.notifcation = data
    }
    )
  }

  sendRequest(){
    this.route.navigateByUrl("Request/offer")
  }


}
