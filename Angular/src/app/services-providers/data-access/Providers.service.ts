import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Providers } from './Classes/Providers';

@Injectable({
  providedIn: 'root',
})
export class ProvidersService {
  providers: Providers[] = []

  constructor(public http:HttpClient) {}

  getAllProviders(id:string){
    return this.http.get<Providers[]>(`https://localhost:7142/api/Provider/ProvidersByService/${id}`)
  }
}
