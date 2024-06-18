import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../models/book.model';
import { BookInfoComponent } from '../book-info/book-info.component';
import { ErrorViewComponent } from '../../../app/components/error-view/error-view.component';
import { BookService } from '../../services/book-service.service';

@Component({
  selector: 'book-details',
  standalone: true,
  imports: [
    BookInfoComponent,
    ErrorViewComponent
  ],
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.css'
})
export class BookDetailsComponent implements OnInit {

       
    id?: string;
    selectedBook?:Book;
  

    constructor(
      private route: ActivatedRoute,
      private router: Router,
      private service: BookService
    ) { 

    }
  ngOnInit(): void {
    this.id= this.route.snapshot.params["id"];
    this.selectedBook=this.service.getBookById(this.id!);
  }

  onDelete(){
    this.service.removeBook(this.selectedBook!.id)
    this.router.navigate(["/books/list"]);
  }

}
