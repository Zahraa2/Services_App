import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './ui/main/main.component';

const routes: Routes = [
  { path:'' , component: MainComponent },
];

export const ServiceProviderRoutesModule = RouterModule.forChild(routes);
