import { Injectable } from '@angular/core';
import { Service } from './Classes/Service';

@Injectable({
  providedIn: 'root'
})
export class ourServicese {

  services: Service[] = [
    new Service('ميكانيكي', 'https://picsum.photos/400/300' , 35 , "تشطيب"),
    new Service('صيانه غاز', 'https://picsum.photos/400/300',32 , "نجاره"),
    new Service('عامل حديد', 'https://picsum.photos/400/300' , 64 ,"نجاره"),
    new Service('طلبيات', 'https://picsum.photos/400/300' , 23,"نجاره"),
    new Service('حديقه', 'https://picsum.photos/400/300', 45,"حداده"),
    new Service('مسبح', 'https://picsum.photos/400/300' , 52,"حداده"),
    new Service('كهربائي', 'https://picsum.photos/400/300' , 87,"حداده"),
    new Service('سباكه', 'https://picsum.photos/400/300' , 21,"حداده"),
    new Service('تعليم', 'https://picsum.photos/400/300' , 34,"حداده"),
    new Service('ديكور', 'https://picsum.photos/400/300', 97,"حداده"),
    new Service('نقل اساس', 'https://picsum.photos/400/300' , 33,"طبخ"),
    new Service('بناء', 'https://picsum.photos/400/300' , 12,"طبخ"),
    new Service('صباغة', 'https://picsum.photos/400/300' , 43,"طبخ"),
    new Service('حديقه', 'https://picsum.photos/400/300', 45,"طبخ"),
    new Service('مسبح', 'https://picsum.photos/400/300' , 52,"طبخ"),
    new Service('كهربائي', 'https://picsum.photos/400/300' , 87,"طبخ"),
    new Service('سباكه', 'https://picsum.photos/400/300' , 21,"نجاره"),
    new Service('تعليم', 'https://picsum.photos/400/300' , 34,"نجاره"),
    new Service('ديكور', 'https://picsum.photos/400/300', 97,"نجاره"),
    new Service('نقل اساس', 'https://picsum.photos/400/300' , 33,"نجاره"),
    new Service('بناء', 'https://picsum.photos/400/300' , 12,"تشطيب"),
    new Service('صباغة', 'https://picsum.photos/400/300' , 43,"تشطيب"),
  ]
constructor() { }

getAllServiecs(){
  return this.services
}

selected:Service[] | any
getSelectedServices(id:string) {

 for(let i =0 ; i < this.services.length ; i++){
  if(this.services[i].cateName == id){
    this.selected.push(this.services[i])
  }
 }
 console.log(this.selected)
 return this.selected
}

}
