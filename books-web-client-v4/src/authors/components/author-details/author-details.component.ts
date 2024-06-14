import { Component } from "@angular/core";
import Author from '../../models/author.model';
@Component({
    standalone: true,
    selector: 'author-details',
    templateUrl:'author-details.component.html',
    styleUrls: ['./author-details.component.css'],
    
})
export class AuthorDetailsComponent{
   
    author= new Author('vivek',
        "Vivek D Mishra",
        'The Author of The Lost Epic Series and Manas',
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s");
}

