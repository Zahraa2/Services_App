import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileRoutesModule } from './profile.routing.module';
import { ProfileComponent } from './UI/profile.component';
import { ProfileInfoComponent } from './feature/profileInfo/profileInfo.component';
import { FormsModule } from '@angular/forms';
import { EditProfileInfoComponent } from './feature/EditProfileInfo/EditProfileInfo.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from '../Auth/token.interceptor';
import { AddPofilePostComponent } from './feature/AddProfilePost/AddProfilePost.component';
import { CustomerRequestServiceComponent } from '../notification/feature/CustomerRequestService/CustomerRequestService.component';



const importedComponent = [
  ProfileInfoComponent,EditProfileInfoComponent , AddPofilePostComponent , CustomerRequestServiceComponent
]


@NgModule({
  declarations: [
    ProfileComponent , importedComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ProfileRoutesModule
  ], 
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
   exports: [
    ProfileComponent,
  ],
})
export class ProfileModule { }
