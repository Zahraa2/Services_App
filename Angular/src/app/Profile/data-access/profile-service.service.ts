import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Profile } from './Classes/Profile';

@Injectable({
    providedIn: 'root'
})
export class ProfileService {

   
    constructor(public http: HttpClient) { }

    getProfileData(){
        return this.http.get<Profile>("http://localhost:3000/Profiles/")
    }

}
