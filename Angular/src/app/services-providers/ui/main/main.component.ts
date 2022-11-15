import { Component, OnInit } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ProvidersService} from '../../data-access/Providers.service'

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
  providers:[ProvidersService]
})
export class MainComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
