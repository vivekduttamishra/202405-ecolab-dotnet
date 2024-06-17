import { Component } from "@angular/core";
import {Author} from '../../models/author.model';
import { SimpleAuthorService } from "../../services/simple-author.service";
import { ActivatedRoute, Router } from "@angular/router";
import { ErrorViewComponent } from '../../../app/components/error-view/error-view.component';
import { DatePipe } from "@angular/common";


@Component({
    standalone: true,
    selector: 'author-details',
    // providers:[
    //     SimpleAuthorService
    // ],
    imports:[
        ErrorViewComponent,
        DatePipe
    ],
    templateUrl:'author-details.component.html',
    styleUrls: ['./author-details.component.css'],
    
})
export class AuthorDetailsComponent{
   
    
    constructor(
        private _authorService: SimpleAuthorService,
        private _route: ActivatedRoute,
        private _router: Router
        
    ) {
        
    }

    author?: Author;
    id?:string;

    ngOnInit(){
        this.id= this._route.snapshot.params["id"];
        this.author= this._authorService.getAuthorById(this.id!);
    }

    handleDelete(){
        this._authorService.removeAuthor(this.id!);
        console.log('remaining authors', 
                    this._authorService.getAuthors());
        this._router.navigate(['/authors/list']);
    }
    


}

