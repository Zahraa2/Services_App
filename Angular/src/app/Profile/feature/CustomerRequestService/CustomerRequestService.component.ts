import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerRequest } from 'src/app/notification/data-access/classes/CustomerRequest';
import { ProfileService } from '../../data-access/profile-service.service';

@Component({
  selector: 'app-CustomerRequestService',
  templateUrl: './CustomerRequestService.component.html',
  styleUrls: ['./CustomerRequestService.component.css']
})
export class CustomerRequestServiceComponent implements OnInit {

  customerResquest:CustomerRequest={
    name:'',
    description:'',
    requestType:'',
    location:'',
    custmoerSendDate:new Date(),
    providerId:''
  }


  constructor(public Provider:ProfileService , public route:Router) { }

  ngOnInit() {
  }

  sendRequest(){
    this.customerResquest.providerId = this.Provider.getProviderId();
    this.route.navigateByUrl('Profile')
  }

}
