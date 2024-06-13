import { Component } from "@angular/core";
import { AppHeaderComponent} from "./components/app-header/app-header.component";
import { AuthorDetailsComponent } from "./components/author-details/author-details.component";
import { BookListComponent } from "./components/book-list/book-list.component";
import { AppFooterComponent } from "./components/app-footer/app-footer.component";

@Component({
    standalone: true, //no modules needed
    selector: 'books-app',
    template:`
        <div class='app'>
            <app-header title="World Wide Books"></app-header>
            <book-list></book-list>
            <app-footer url='http://conceptarchitect.in' text="Concept Architect" ></app-footer>
        </div>
        `,

    imports:[
        AppHeaderComponent,
        AppFooterComponent,
        AuthorDetailsComponent,
        BookListComponent 
    ]
  
        
})
export class BooksAppComponent{
    
}
 
