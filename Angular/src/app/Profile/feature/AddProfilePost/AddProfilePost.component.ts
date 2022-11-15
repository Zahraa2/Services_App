import { Component, OnInit } from '@angular/core';
import { Profile } from '../../data-access/Classes/Profile';
import { ProfileService } from '../../data-access/profile-service.service';

@Component({
  selector: 'app-AddProfilePost',
  templateUrl: './AddProfilePost.component.html',
  styleUrls: ['./AddProfilePost.component.css']
})
export class AddPofilePostComponent implements OnInit {

  Profile:Profile = {ServiceName:'', Pic:'',Name:'',Summary:'',Location:'',Rate:0,Posts:[]}
  constructor(public profileService:ProfileService) { }

  ngOnInit() {
    this.profileService.getProfileData().subscribe( a =>{
      this.Profile = a
    })
  }
  readURL(uploded:HTMLElement){
    
  }

}
