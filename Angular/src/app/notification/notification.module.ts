import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotificationRoutingModule } from './notification-routing.module';
import { NotificationComponent } from './UI/notification.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    NotificationComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    NotificationRoutingModule
  ]
})
export class NotificationModule { }
