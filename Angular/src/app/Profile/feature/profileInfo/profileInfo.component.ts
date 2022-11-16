import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from '../../data-access/Classes/Profile';
import { ProfileService } from '../../data-access/profile-service.service';

@Component({
  selector: 'app-profileInfo',
  templateUrl: './profileInfo.component.html',
  styleUrls: ['./profileInfo.component.css']
})


export class ProfileInfoComponent implements OnInit {


  profile:Profile = {ServiceName:'', Pic:'',Name:'',Summary:'',Location:'',Rate:0,Posts:[]}

  constructor(public routeActive:Router  , public profileData:ProfileService) { }

  ngOnInit() {

    this.profileData.getProfileData().subscribe( a => {
      this.profile = a
    })
  }
  


  EditInfo(){
    this.routeActive.navigateByUrl('Profile/Edit')
  }
  imgOptions(){
    this.routeActive.navigateByUrl('Profile/Add-Post')
  }

}
