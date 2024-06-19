import { Injectable } from "@angular/core";
import { Author } from "../models/author.model";
import { HttpClient } from "@angular/common/http";


const url='http://localhost:5000/api/authors';

@Injectable({
    providedIn: 'root'
})
export class SimpleAuthorService{
    
    constructor(private http: HttpClient) {
        this.serviceId=++ SimpleAuthorService._lastId;  
        console.log(`SimpleAuthorService #${this.serviceId} created`);      
        
        
    }

    getAuthors() {
        
       var token = localStorage.getItem('token');
       let headers:any={};

       if(token){
        headers['Authorization']=`Bearer ${token}`;
       }

       return  this
            .http
            .get<Author[]>(url,{headers});
    }

    getAuthorById(id:string) {

        return this.authors.find(author => author.id === id);
    
    }

    removeAuthor(id:String){
        this.authors= this.authors.filter(a=>a.id!==id);
    }

    private authors: Author[]=[];
    static _lastId=0;
    private serviceId:number;

}