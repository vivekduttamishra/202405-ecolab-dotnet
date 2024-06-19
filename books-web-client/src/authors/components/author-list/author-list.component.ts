import { Component } from '@angular/core';
import { Author } from '../../models/author.model';
import { SimpleAuthorService } from '../../services/simple-author.service';
import { Router, RouterLink } from '@angular/router';
import { CaLoadingComponent } from '../../../utils/components/ca-loading/ca-loading.component';

@Component({
  selector: 'author-list',
  standalone: true,
  imports: [
    RouterLink,
    CaLoadingComponent,
    
  ],
  providers:[
    
  ],
  templateUrl: './author-list.component.html',
  styleUrl: './author-list.component.css'
})
export class AuthorListComponent {
    authors?: Author[];

    constructor(
      private _authorService: SimpleAuthorService,
      private _router: Router
    ) {}


    ngOnInit(){
      this._authorService
            .getAuthors()
            .pipe(

            ).subscribe({

              next: (authors: Author[])=>{
                this.authors=authors;
              },

              error: (err: any)=>{
                this._router.navigate(['/user/login']);
              },             

            })

    }

}
