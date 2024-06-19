import { Injectable } from "@angular/core";
import { Author } from "../models/author.model";


@Injectable({
    providedIn: 'root'
})
export class SimpleAuthorService{
    private authors: Author[];
    static _lastId=0;
    private serviceId:number;
    constructor() {
        this.serviceId=++ SimpleAuthorService._lastId;  
        console.log(`SimpleAuthorService #${this.serviceId} created`);      
        this.authors=[
            {
                id: 'vivek',
                name: "Vivek D Mishra",
                biography: 'The Author of The Lost Epic Series and Manas',
                photograph: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s",
                birthDate: '1977-07-09' //yyyy-mm-dd format
            },
            {
                id: 'mahatma-gandhi',
                name: "Mahatma Gandhi",
                biography: 'The Father of the Nation for India',
                photograph: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR66y5OPq53ij94lUah9ZikjOPtSCXjFVF38g&s",
                birthDate: new Date(1869, 10,2)
            }
        ] ;       
        
    }

    getAuthors(): Author[] {
        return this.authors;
    }

    getAuthorById(id:string) {

        return this.authors.find(author => author.id === id);
    
    }

    removeAuthor(id:String){
        this.authors= this.authors.filter(a=>a.id!==id);
    }

}