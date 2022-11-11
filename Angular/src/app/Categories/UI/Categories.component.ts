import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { fader} from 'src/app/Anmimations/routeranimation';

@Component({
  selector: 'app-Categories',
  templateUrl: './Categories.component.html',
  styleUrls: ['./Categories.component.css'],
  animations:[fader]

})
export class CategoriesComponent implements OnInit {


  constructor() { }

  ngOnInit() {
  }
  prepareRoute(outlet: RouterOutlet) {
  return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }

}
