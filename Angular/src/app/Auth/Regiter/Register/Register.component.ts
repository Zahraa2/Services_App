import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {

  }

  regUser() {
  this.router.navigate(['userRegister']);

  }

  regProvider(){
    this.router.navigate(['sellerRegister']);
  }
}
