import { Component } from "@angular/core";
import { AppHeaderComponent } from "./components/app-header/app-header.component";
import { AppFooterComponent } from "./components/app-footer/app-footer.component";
import { BookListComponent } from "../books/components/book-list/book-list.component";


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
        BookListComponent,
    ]
  
        
})
export class BooksAppComponent{
    
}
 
