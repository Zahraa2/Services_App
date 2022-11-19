import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllRquestComponent } from './feature/AllRquest/AllRquest.component';
import { CustomerRequestServiceComponent } from './feature/CustomerRequestService/CustomerRequestService.component';
import { ProviderRequestComponent } from './feature/providerRequest/providerRequest.component';
import { RequestDetailsComponent } from './feature/RequestDetails/RequestDetails.component';



const routes: Routes = [
  { path: '', component: CustomerRequestServiceComponent },
  { path: 'details', component: RequestDetailsComponent },
  { path: 'all-Request', component: AllRquestComponent },
  { path: 'offer', component: ProviderRequestComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NotificationRoutingModule { }
