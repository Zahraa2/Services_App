import { Component, OnInit } from '@angular/core';
import { Service } from 'src/app/Categories/data-access/Classes/Service';
import { ourServicese } from 'src/app/Categories/data-access/Services.service';
import { Profile } from '../../data-access/Classes/Profile';
import { ProfileService } from '../../data-access/profile-service.service';

@Component({
  selector: 'app-EditProfileInfo',
  templateUrl: './EditProfileInfo.component.html',
  styleUrls: ['./EditProfileInfo.component.css']
})
export class EditProfileInfoComponent implements OnInit {

  profile:Profile = {ServiceName:'', Pic:'',Name:'',Summary:'',Location:'',Rate:0,Posts:[]}
  service: Service | any
  constructor(public profileService:ProfileService , public allService:ourServicese) { }

  ngOnInit() {
    this.profileService.getProfileData().subscribe( a =>{
      this.profile = a
    })
    this.allService.getAllServiecs().subscribe(a =>{
      this.service  = a
    }
      )
  }

}
