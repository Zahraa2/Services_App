import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as signalR from '@microsoft/signalr';
import { Subscription } from 'rxjs';
import { CustomerRequest } from 'src/app/notification/data-access/classes/CustomerRequest';
import { SignalRService } from 'src/app/notification/data-access/SignalR.service';
import { ProfileService } from '../../../Profile/data-access/profile-service.service';
import { NotificationsService } from '../../data-access/notifications.service';

@Component({
  selector: 'app-CustomerRequestService',
  templateUrl: './CustomerRequestService.component.html',
  styleUrls: ['./CustomerRequestService.component.css']
})
export class CustomerRequestServiceComponent implements OnInit {

  Types: string[] = ["معاينة", "تصليح", "تشطيب كامل"]
  customerResquest: CustomerRequest = {
    name: '',
    description: '',
    requestType: '',
    custmoerSendDate: (new Date()).toString(),
    location: '',
    providerId: this.Provider.getProviderId(),
    customerId: this.Provider.getCustomerId(),
    massage: '',
    image: '',
    price:null,
    id:''
  }

  customer: CustomerRequest[] = []
  allRequestSubscription: any;
  private subscriptions = new Subscription()


  constructor(public Provider: ProfileService, public route: Router, public request: NotificationsService , public signalR:SignalRService) { }


  ngOnInit() {

  }

  sendRequest() {

    console.log(this.customerResquest)

    this.request.CustomerRequest(this.customerResquest).subscribe(() => console.log("hello"),
      error => console.log(error))
    this.signelConnection()

    this.route.navigateByUrl('Profile')
  }

  signelConnection() {
    //send data to server by Invoke
    const sendCustomerRequest = this.signalR.invoke("CustomerSendNotification", this.customerResquest).subscribe()
    this.subscriptions.add(sendCustomerRequest);

    // //recive data from ON
    this.allRequestSubscription = this.signalR.on("ProviderReciveNotification")

    //print data
    console.log(this.allRequestSubscription)
  }





}
