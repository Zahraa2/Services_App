import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationRoutingModule } from './notification-routing.module';
import { NotificationComponent } from './UI/notification.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AllRquestComponent } from './feature/AllRquest/AllRquest.component';
import { ProviderRequestComponent } from './feature/providerRequest/providerRequest.component';
import { CustomerRequestServiceComponent } from './feature/CustomerRequestService/CustomerRequestService.component';


const importedComponent = [
  NotificationComponent , AllRquestComponent , ProviderRequestComponent 
]

@NgModule({
  declarations: [
    importedComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    NotificationRoutingModule,
    FormsModule
  ]
})
export class NotificationModule { }
