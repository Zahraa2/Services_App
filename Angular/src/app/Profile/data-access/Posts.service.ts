import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from './Classes/Post';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';  


@Injectable({
  providedIn: 'root'
})
export class PostsService {

   baseUrl:string = "https://localhost:7142/api/Posts/";
   Header = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private httpClient: HttpClient) { }

  // Posts handel Functions

  getAllPosts(id:string):Observable<Post[]> {
   
    let url = `${this.baseUrl}PostsOfProvider/${id}`;
    return this.httpClient.get<Post[]>(url)
    .pipe(
      catchError(this.handelErrors)
    );
  }

  createPost(data: any):Observable<Post> {

    let url = `${this.baseUrl}AddPost/`;
    return this.httpClient.post<Post>(url, data , {headers: this.Header})
    .pipe(
      catchError(this.handelErrors)
    );
  }



  updatePost(data: Post):Observable<Post> {
    debugger

    let url = `${this.baseUrl}UpdatePost/${data.ProviderId}`;
   return this.httpClient.put<Post>(url, data , {headers: this.Header})
    .pipe(
      map( () => data),
      catchError(this.handelErrors)
    );
  }


  deletePost(id: string):Observable<{}> {

    let url = `${this.baseUrl}DeletePost/${id}`;
   return this.httpClient.delete(url ,{headers : this.Header} )  
  }

  private handelErrors(err:any){
    let errorMasssage:string 
    if(err.error instanceof ErrorEvent){
      errorMasssage = `an error occured ${err.error.message}`;
    }else{
      errorMasssage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);  
    return throwError(errorMasssage); 
  }


}
