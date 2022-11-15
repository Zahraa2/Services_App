import { Component, OnInit } from '@angular/core';
import { Providers } from '../../data-access/Classes/Providers';
import { ProvidersService } from '../../data-access/Providers.service';

@Component({
  selector: 'app-provider-profile',
  templateUrl: './provider-profile.component.html',
  styleUrls: ['./provider-profile.component.css']
})
export class ProviderProfileComponent implements OnInit {
  providers:Providers[]=[]
  constructor(public provider:ProvidersService) { }

  ngOnInit(): void {
    this.providers=this.provider.getAllProviderss();
  }

}
