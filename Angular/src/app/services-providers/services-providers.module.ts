import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProvidersHeaderComponent } from './ui/providers-header/providers-header.component';
import { ShareModule } from '../Share/share.module';
import { ProviderProfileComponent } from './ui/provider-profile/provider-profile.component';
import { MainComponent } from './ui/main/main.component';
import { RouterModule } from '@angular/router';
import { NavBarComponent } from './ui/nav-bar/nav-bar.component';
import { ServiceProviderRoutesModule } from './service.provider.routing.module';
@NgModule({
  declarations: [
    ProvidersHeaderComponent,
    ProviderProfileComponent,
    MainComponent,
    NavBarComponent,
    // DataAccessComponent,
  ],
  imports: [
    CommonModule,
    // ShareModule,
    RouterModule,
    ServiceProviderRoutesModule
  ],
  exports:[
    ProvidersHeaderComponent,
    MainComponent
  ]
})
export class ServicesProvidersModule { }