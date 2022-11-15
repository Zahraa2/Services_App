import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileRoutesModule } from './profile.routing.module';
import { ProfileComponent } from './UI/profile.component';
import { ProfileInfoComponent } from './feature/profileInfo/profileInfo.component';
import { FormsModule } from '@angular/forms';
import { EditProfileInfoComponent } from './feature/EditProfileInfo/EditProfileInfo.component';




const importedComponent = [
  ProfileInfoComponent,EditProfileInfoComponent
]


@NgModule({
  declarations: [
    ProfileComponent , importedComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ProfileRoutesModule
  ],
  exports: [
    ProfileComponent
  ]
})
export class ProfileModule { }
