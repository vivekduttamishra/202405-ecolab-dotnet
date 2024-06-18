import { Component } from '@angular/core';
import { Author } from '../../models/author.model';
import { SimpleAuthorService } from '../../services/simple-author.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'author-list',
  standalone: true,
  imports: [
    RouterLink
  ],
  // providers:[
  //   SimpleAuthorService
  // ],
  templateUrl: './author-list.component.html',
  styleUrl: './author-list.component.css'
})
export class AuthorListComponent {
    authors?: Author[];

    constructor(
      private _authorService: SimpleAuthorService
    ) {}

    ngOnInit(){
      this.authors=this._authorService.getAuthors();
    }

}
