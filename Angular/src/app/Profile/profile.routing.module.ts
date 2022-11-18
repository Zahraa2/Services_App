import { Routes, RouterModule } from '@angular/router';
import { EditProfileInfoComponent } from './feature/EditProfileInfo/EditProfileInfo.component';
import { AddPofilePostComponent} from './feature/AddProfilePost/AddProfilePost.component';
import { ProfileComponent } from './UI/profile.component';
import { CustomerRequestServiceComponent } from './feature/CustomerRequestService/CustomerRequestService.component';

const routes: Routes = [
  {path:'' , component: ProfileComponent },
  {path:'Edit' , component: EditProfileInfoComponent },
  {path:'Add-Post' , component: AddPofilePostComponent },
  {path:'Customer-Request' , component:CustomerRequestServiceComponent}
];

export const ProfileRoutesModule = RouterModule.forChild(routes);
