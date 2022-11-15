import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Auth/services/auth.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  
  userData : any
  name: any
  role : any
  constructor(private authService:AuthService, private http:HttpClient) { 
    
  }
  ngOnInit() {
    
    this.http.get('https://localhost:7142/api/Auth/GetLoggedInUser')
    .subscribe(resData => {
      this.userData = resData; 
      this.name = this.userData.name
      this.role = (this.userData.type === 0) ? 'customer' :'serviceProvider';
    });

  }

}
