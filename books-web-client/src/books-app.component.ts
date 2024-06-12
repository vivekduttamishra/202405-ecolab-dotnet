import { Component } from "@angular/core";
import { AppHeaderComponent} from "./components/app-header/app-header.component";
import { AuthorDetailsComponent } from "./components/author-details/author-details.component";
import { BookListComponent } from "./components/book-list/book-list.component";

@Component({
    standalone: true, //no modules needed
    selector: 'books-app',
    template:`
        <div class='app'>
            <app-header></app-header>
            <book-list></book-list>
        </div>
        `,

    imports:[
        AppHeaderComponent,
        AuthorDetailsComponent,
        BookListComponent 
    ]
  
        
})
export class BooksAppComponent{
    
}
 
