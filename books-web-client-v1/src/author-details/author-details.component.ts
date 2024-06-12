import { Component } from "@angular/core";
import AuthorInfo from '../author';

@Component({
    standalone: true,
    selector: 'author-details',
    templateUrl:'author-details.component.html',
    styleUrls: ['./author-details.component.css'],
    
})
export class AuthorDetailsComponent{
    title="World Wide Books";
    slogan="The Official Home Page of all the books in the world";
    
    author= new AuthorInfo('vivek',
        "Vivek Dutta Mishra",'The Author of The Lost Epic Series and Manas',"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s");
}

