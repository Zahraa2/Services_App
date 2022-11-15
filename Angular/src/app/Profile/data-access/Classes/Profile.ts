import { Post } from "./Post";

export interface Profile {
    ServiceName:string,
    Pic:string,
    Name:string,
    Summary:string,
    Location:string,
    Rate:number,
    Posts:Post[]
}



