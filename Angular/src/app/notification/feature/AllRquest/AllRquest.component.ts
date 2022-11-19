import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserLogged } from 'src/app/Profile/data-access/Classes/UserLogged';
import { ProfileService } from 'src/app/Profile/data-access/profile-service.service';
import { CustomerRequest } from '../../data-access/classes/CustomerRequest';
import { NotificationsService } from '../../data-access/notifications.service';

@Component({
  selector: 'app-AllRquest',
  templateUrl: './AllRquest.component.html',
  styleUrls: ['./AllRquest.component.css']
})
export class AllRquestComponent implements OnInit {

 
  container:CustomerRequest[] = []
  customerNotifcation:CustomerRequest | any
  constructor(public notifications:NotificationsService , public profile:ProfileService , public http:HttpClient , public router:Router) { }

  ngOnInit() {
       this.http.get<UserLogged>("https://localhost:7142/api/Auth/GetLoggedInUser").subscribe(data => {
        if (data.type === 0) {
          this.notifications.getAllCustomerNotification(data.id).subscribe((data:CustomerRequest[]) =>{
            for(let i = 0 ; i < data.length ; i++){
              if(data[i].price != null ){
                  this.container.push(data[i])
              }
            }
          })
       
        } else {
          this.notifications.getAllProviderNotification(data.id).subscribe(data =>{
            for(let i = 0 ; i < data.length ; i++){
              if(data[i].price === null ){
                  this.container.push(data[i])
              }
            }
          })
        }
      })
        
  }

  notificationsDetalis(id:string){
    this.notifications.setPostId(id)
    this.router.navigateByUrl("Request/details")
  }

}
