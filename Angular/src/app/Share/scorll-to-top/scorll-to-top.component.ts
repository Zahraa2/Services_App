import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-scorll-to-top',
  templateUrl: './scorll-to-top.component.html',
  styleUrls: ['./scorll-to-top.component.css']
})
export class ScorllToTopComponent implements OnInit {
  windowScrolled = false;

  ngOnInit() {
    window.addEventListener('scroll', () => {
      if(window.pageYOffset>300){
        this.windowScrolled=true
      }
      else{
        this.windowScrolled=false
      }
    });
  }
  scrollToTop(): void {
    window.scrollTo(0, 0);
  }
}
