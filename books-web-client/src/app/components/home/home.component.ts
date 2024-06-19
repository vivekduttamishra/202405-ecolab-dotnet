import { Component, OnDestroy, OnInit } from '@angular/core';
import { BookService } from '../../../books/services/book-service.service';
import { Book } from '../../../books/models/book.model';
import { Observable, Subscription, filter, map, tap } from 'rxjs';
import { CaLoadingComponent } from '../../../utils/components/ca-loading/ca-loading.component';

@Component({
  selector: 'books-home',
  standalone: true,
  imports: [
   CaLoadingComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy {

    constructor(  
      private bookService: BookService
    ){}
  

    books?: Book[];
    subscription?:Subscription;
    
    ngOnInit(){
      this.subscription=this.bookService
                            .getRecommendedBooks(3, 5000)
                            .subscribe({
                              next: (books:Book[])=> {this.books = books;} 
                            });



      

      this.singleBookSusbcription = this.bookService
                                        .getBookRecommendations(3,2000)
                                        .pipe(
                                            tap((data:any)=>console.log("original data: " , data)),
                                            filter((book:Book)=> book.author.includes("Vivek")),
                                            map((data:any)=>{
                                              console.log("map got",data);
                                              return data.title;
                                            }),
                                            tap((data:any)=>console.log("modified data: " , data)),                                         

                                        );
    }


    singleBookSusbcription?:Observable<Book>;

    data:any[]=[];

    status="idle";
    handleFetchBookClick(){
      this.status="active";
      this.singleBookSusbcription!.subscribe({
        
          //on success
          next: book => this.data.push(book),
        
          //on error
          error: err=>console.log('error',err),

          //on complete
          complete:()=>{
            console.log('completed');
            this.status="done";
          }

      })


      
    
    }



    ngOnDestroy(): void {
      this.subscription?.unsubscribe();
    }

      

}
