import { Component, OnInit } from '@angular/core';


// NavBar Toggeler 

@Component({
  selector: 'app-Navbar',
  templateUrl: './Navbar.component.html',
  styleUrls: ['./Navbar.component.css']
})


export class NavbarComponent implements OnInit {
  language: string = "العربية"
  seconedLanguage: string = "الإنجليزية"
  toggleArabic: boolean = true
  toggle:boolean = false;
  constructor() { }

  ngOnInit() {
  }
  handleToggle(){
    this.toggle = !this.toggle;
  }

  handleToggleLang(){
    this.toggleArabic = !this.toggleArabic
    if (this.toggleArabic) { 
      this.language = "العربية"
      this.seconedLanguage = "الإنجليزية"
    } else {
      this.seconedLanguage = "العربية"
      this.language = "الإنجليزية"
    }
  }

}
