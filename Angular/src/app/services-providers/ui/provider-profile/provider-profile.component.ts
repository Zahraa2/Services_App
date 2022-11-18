import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ourServicese } from 'src/app/Categories/data-access/Services.service';
import { ProfileService } from 'src/app/Profile/data-access/profile-service.service';
import { Providers } from '../../data-access/Classes/Providers';
import { ProvidersService } from '../../data-access/Providers.service';

@Component({
  selector: 'app-provider-profile',
  templateUrl: './provider-profile.component.html',
  styleUrls: ['./provider-profile.component.css']
})
export class ProviderProfileComponent implements OnInit {

  providers: Providers[] = []
  constructor(public provider: ProvidersService , public setProviderId:ProfileService, public selectedService: ourServicese , public route:Router) { }

  ngOnInit(): void {
    this.provider.getAllProviders(this.selectedService.getProviderServices()).subscribe(allProviders => {
      this.providers = allProviders
    })
  }
  profileRoute(id:string){
    this.route.navigateByUrl("Profile")
    this.setProviderId.setProviderId(id)
  }

}
