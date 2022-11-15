import { Injectable } from '@angular/core';
import { Providers } from './Classes/Providers';

@Injectable({
  providedIn: 'root',
})
export class ProvidersService {
  providers: Providers[] = [
    new Providers(
      'نجاره',
      'https://static.vecteezy.com/ti/vetor-gratis/t1/547547-praia-tropical-e-fundo-azul-do-mar-da-onda-vetor.jpg',
      'ali',
      'fekf efmme',
      'cairo'
    ),
    new Providers(
      'نجاره',
      'https://static.vecteezy.com/ti/vetor-gratis/t1/547547-praia-tropical-e-fundo-azul-do-mar-da-onda-vetor.jpg',
      'sara',
      'rgmvpomer eromerf  nreonoqt4 ',
      'cairo'
    ),
    new Providers(
      'نجاره',
      'https://static.vecteezy.com/ti/vetor-gratis/t1/547547-praia-tropical-e-fundo-azul-do-mar-da-onda-vetor.jpg',
      'ahmed',
      'rgmvpomer eromerf  nreonoqt4 ',
      'cairo'
    ),
    new Providers(
      'نجاره',
      'https://static.vecteezy.com/ti/vetor-gratis/t1/547547-praia-tropical-e-fundo-azul-do-mar-da-onda-vetor.jpg',
      'khaled',
      'rgmvpomer eromerf  nreonoqt4 ',
      'cairo'
    ),
  ];
  service = 'نجاره';
  selectedProviders: Providers[] =[]
  constructor() {}
  getAllProviderss() {
    for(let i =0;i<this.providers.length;i++){
      if(this.providers[i].servicesName==this.service){
        this.selectedProviders.push(this.providers[i]);
      }
    }
    return this.selectedProviders;
  }
}
