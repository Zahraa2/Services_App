import { Routes, RouterModule } from '@angular/router';
import { EditProfileInfoComponent } from './feature/EditProfileInfo/EditProfileInfo.component';
import { AddPofilePostComponent} from './feature/AddProfilePost/AddProfilePost.component';
import { ProfileComponent } from './UI/profile.component';

const routes: Routes = [
  {path:'' , component: ProfileComponent },
  {path:'Edit' , component: EditProfileInfoComponent },
  {path:'Add-Post' , component: AddPofilePostComponent },
];

export const ProfileRoutesModule = RouterModule.forChild(routes);
