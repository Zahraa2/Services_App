import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ourServicese } from 'src/app/Categories/data-access/Services.service';
import { ProvidersService } from 'src/app/services-providers/data-access/Providers.service';
import { Post } from '../../data-access/Classes/Post';
import { Profile } from '../../data-access/Classes/Profile';
import { PostsService } from '../../data-access/Posts.service';
import { ProfileService } from '../../data-access/profile-service.service';

@Component({
  selector: 'app-profileInfo',
  templateUrl: './profileInfo.component.html',
  styleUrls: ['./profileInfo.component.css']
})


export class ProfileInfoComponent implements OnInit {

  errorMessage:string = ''
  editOption:any = this.profileData.comparison()
  Posts:Post[] = []
  profile: Profile = { id: '', serviceName: '', profilePicture: 'assets/Images/Profile/Default-Profile-Picture.png', name: '', sammary: '', location: '', avgRate: 0 }
  provId:string = ''
  constructor(public routeActive: Router, public profileData: ProfileService ,public userPosts:PostsService) { }

  
  ngOnInit() {
    this.getProfileData();
    this.getAllPosts()
  }

  //Provider Data
  getProfileData(){
    this.provId= this.profileData.getProviderId();    
    this.profileData.getProfileData(this.provId).subscribe(data => {
      this.profile = data
    }
    )
  }

  //Provider Posts Data
  getAllPosts(){
  this.userPosts.getAllPosts().subscribe(posts =>{
    this.Posts = posts
  }, (error: any) => this.errorMessage = <any>error
  )}


  
  EditInfo(){
    this.routeActive.navigateByUrl('Profile/Edit')
  }
  imgOptions(){
    this.routeActive.navigateByUrl('Profile/Add-Post')
  }
  customerRequest(){
    this.routeActive.navigateByUrl('Profile/Customer-Request')
  }

}
