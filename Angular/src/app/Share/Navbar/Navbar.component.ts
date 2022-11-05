import { Component, OnInit } from '@angular/core';


// NavBar Toggeler 



@Component({
  selector: 'app-Navbar',
  templateUrl: './Navbar.component.html',
  styleUrls: ['./Navbar.component.css']
})


export class NavbarComponent implements OnInit {
  toggle:boolean = false;
  constructor() { }

  ngOnInit() {
  }
  handleToggle(){
    this.toggle = !this.toggle;
  }

}
