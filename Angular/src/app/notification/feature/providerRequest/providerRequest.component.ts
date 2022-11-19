import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProfileService } from 'src/app/Profile/data-access/profile-service.service';
import { Respons } from '../../data-access/classes/Respons';
import { NotificationsService } from '../../data-access/notifications.service';

@Component({
  selector: 'app-providerRequest',
  templateUrl: './providerRequest.component.html',
  styleUrls: ['./providerRequest.component.css']
})
export class ProviderRequestComponent implements OnInit {

  respons:Respons = {
    providerId: this.Provider.getProviderId(),
    customerId: this.Provider.getCustomerId(),
    id:"",
    message:""
  }
  constructor(public notifications:NotificationsService ,public Provider: ProfileService ) { }

  ngOnInit() {

  }


}
