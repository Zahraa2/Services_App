import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { ourServicese } from 'src/app/Categories/data-access/Services.service';
import { ProvidersService } from 'src/app/services-providers/data-access/Providers.service';
import { Post } from '../../data-access/Classes/Post';
import { Profile } from '../../data-access/Classes/Profile';
import { PostsService } from '../../data-access/Posts.service';
import { ProfileService } from '../../data-access/profile-service.service';
import { HttpClient } from '@angular/common/http';
import { UserLogged } from '../../data-access/Classes/UserLogged';
@Component({
  selector: 'app-profileInfo',
  templateUrl: './profileInfo.component.html',
  styleUrls: ['./profileInfo.component.css']
})


export class ProfileInfoComponent implements OnInit , OnChanges {

  errorMessage:string = ''
  // editOption:any = this.profileData.getUserLoggedInfo()
  editOption:any 
  clientOptions:any
  imgOptionClass:string = ''
  Posts:Post[] = []
  profile: Profile = { id: '', serviceName: '', profilePicture: 'assets/Images/Profile/Default-Profile-Picture.png', name: '', sammary: '', location: '', avgRate: 0 }
  provId:string = ''
  constructor(public routeActive: Router, public profileData: ProfileService ,public userPosts:PostsService ,public http: HttpClient) { }
  ngOnChanges(changes: SimpleChanges): void {
    throw new Error('Method not implemented.');
  }

  
  ngOnInit() {
    this.getProfileData();
    this.getAllPosts();

    this.http.get<UserLogged>("https://localhost:7142/api/Auth/GetLoggedInUser").subscribe(data =>{
      if(this.profileData.getProviderId() == data.id){
        this.editOption = true
        this.imgOptionClass = "options-container"
      }else{
        this.editOption = false
        this.imgOptionClass = ''
      }

      if(data.userType == 0){
        this.clientOptions = true
      }else{
        this.clientOptions = false
      }
    })
    
  }

  OnChanges(){
    this.getAllPosts();
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
    let id = this.profileData.getProviderId()
  this.userPosts.getAllPosts(id).subscribe(posts =>{
    this.Posts = posts
  }, (error: any) => this.errorMessage = <any>error
  )}

  deletePost(id:string){
    if(confirm("Are You Sure!!")){
      this.userPosts.deletePost(id).subscribe(
        (data) => console.log(data)  
      )
      this.getAllPosts()
    }
    return
  }




  
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
