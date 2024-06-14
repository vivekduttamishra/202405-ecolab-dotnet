import { Component } from "@angular/core";
import { AppHeaderComponent } from "./components/app-header/app-header.component";
import { AppFooterComponent } from "./components/app-footer/app-footer.component";
import { BookListComponent } from "../books/components/book-list/book-list.component";
import { BookManageComponent } from "../books/components/book-manage/book-manage.component";


@Component({
    standalone: true, //no modules needed
    selector: 'books-app',
    template:`
        <div class='app'>
            <app-header title="World Wide Books"></app-header>
            <book-manage></book-manage>
            <app-footer url='http://conceptarchitect.in' text="Concept Architect" ></app-footer>
        </div>
        `,

    imports:[
        AppHeaderComponent,
        AppFooterComponent,
        BookListComponent,
        BookManageComponent
    ]
  
        
})
export class BooksAppComponent{
    
}
 
