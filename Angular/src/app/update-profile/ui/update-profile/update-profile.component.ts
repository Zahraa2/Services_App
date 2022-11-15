import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.css'],
})
export class UpdateProfileComponent implements OnInit {
  Name: string = 'ali';
  Address: string = 'cairo';
  img: string = 'https://i.imgur.com/hczKIze.jpg';

  ChangeInfo(name: string, add: string) {
    if (this.Name == name && this.Address == add) {
      console.log('no change');
    } else {
      this.Name = name;
      this.Address = add;
      console.log(this.Name);
      console.log(this.Address);
    }
  }
  constructor() {}

  ngOnInit(): void {}
}
