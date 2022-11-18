import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
    location: '',
    custmoerSendDate: new Date(),
    providerId: '',
    customerId: ''
  }

  customer: CustomerRequest[] = []
  allRequestSubscription: any;
  private subscriptions = new Subscription()


  constructor(public Provider: ProfileService, public route: Router, public signalR: SignalRService ,public request:NotificationsService ) { }


  ngOnInit() {
 

  }

  sendRequest() {
    this.customerResquest.providerId = this.Provider.getProviderId();
   this.customerResquest.customerId = this.Provider.getCustomerId();

    console.log(this.customerResquest)
    
    this.request.CustomerRequest(this.customerResquest).subscribe(data =>{
      console.log(data)
    }, error => console.log(error))

    this.signelConnection()
    this.route.navigateByUrl('Profile')


  }

  signelConnection(){
   //send data to server by Invoke
    const sendCustomerRequest = this.signalR.invoke("CustomerSendNotification", this.customerResquest).subscribe()
    this.subscriptions.add(sendCustomerRequest);


    //recive data from ON
    this.allRequestSubscription = this.signalR.on("ProviderReciveNotification").subscribe(
      (data:CustomerRequest) => {
        this.customer.push(data)
      }
    )

    //print data
    console.log(this.customer)
  }

  

}
