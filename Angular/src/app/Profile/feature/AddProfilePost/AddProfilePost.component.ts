import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../../data-access/Classes/Post';
import { Profile } from '../../data-access/Classes/Profile';
import { PostsService } from '../../data-access/Posts.service';
import { ProfileService } from '../../data-access/profile-service.service';

@Component({
  selector: 'app-AddProfilePost',
  templateUrl: './AddProfilePost.component.html',
  styleUrls: ['./AddProfilePost.component.css']
})
export class AddPofilePostComponent implements OnInit {

  errorMessage: string = ''
  Post: Post = {id:'', ProviderId: this.profileService.getProviderId(), image: "assets/Images/Profile/Default-Profile-Picture.png", description: '' }

  constructor(public profileService: ProfileService, public post: PostsService , public router:Router) { }

  ngOnInit() {

  }

  handelImage(file:FileList |any){
    file = file.item(0);

    this.Post.image = file.name
 }
  saveChanges() {
    this.post.createPost(this.Post).subscribe(
      () => console.log("secusess"),
      (error: any) => this.errorMessage = <any>error
    )
    this.router.navigate(['Profile']); 
  }


}


