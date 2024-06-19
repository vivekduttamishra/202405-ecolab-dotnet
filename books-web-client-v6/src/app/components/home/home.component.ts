import { Component, OnDestroy, OnInit } from '@angular/core';
import { BookService,Subscription } from '../../../books/services/book-service.service';
import { Book } from '../../../books/models/book.model';

@Component({
  selector: 'books-home',
  standalone: true,
  imports: [
   
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy {

    constructor(  
      private bookService: BookService
    ){}
  

    books?: Book[];
    susbcription?: Subscription<Book[]>

    ngOnInit(){
      this.susbcription= this.bookService.getRecommendedBooks(3, 5000);
      this.susbcription
          .subscribe(books=>{
          console.log('got new recommendations', books.map(book=>book.title));
          this.books=books;
      });
    }

    ngOnDestroy(): void {
      this.susbcription?.unsubscribe();
    }

      

}
