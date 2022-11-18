import { Component, OnInit } from '@angular/core';


// NavBar Toggeler 

@Component({
  selector: 'app-Navbar',
  templateUrl: './Navbar.component.html',
  styleUrls: ['./Navbar.component.css']
})


export class NavbarComponent implements OnInit {
  constructor() {}
  lang:string="";
  ngOnInit():void {
    this.lang=localStorage.getItem("lang")||"en"
   }
  
 //change languge in local storage
  changLang(lang:string){
    console.log(lang);
    localStorage.setItem("lang",lang);
    window.location.reload()
  }
}
