import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../models/book.model';
import { BookInfoComponent } from '../book-info/book-info.component';
import { ErrorViewComponent } from '../../../app/components/error-view/error-view.component';
import { BookService } from '../../services/book-service.service';
import { CaLoadingComponent } from '../../../utils/components/ca-loading/ca-loading.component';

@Component({
  selector: 'book-details',
  standalone: true,
  imports: [
    BookInfoComponent,
    ErrorViewComponent,
    CaLoadingComponent
  ],
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.css'
})
export class BookDetailsComponent implements OnInit {


  id?: string;

  selectedBook?: Book | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: BookService
  ) {

  }
  ngOnInit(): void {
    this.id = this.route.snapshot.params["id"];
    //this.selectedBook=this.service.getBookById(this.id!);
    this.fetchBookDetails();
  }

  async fetchBookDetails() {
    try {

      this.selectedBook = await this.service.getBookById(this.id!);
    } catch (err) {
      this.selectedBook = undefined;
    }
  }

  onDelete() {
    this.service.removeBook(this.selectedBook!.id)
    this.router.navigate(["/books/list"]);
  }

}
