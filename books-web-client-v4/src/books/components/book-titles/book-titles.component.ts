import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Book } from '../../models/book.model';

@Component({
  selector: 'book-titles',
  standalone: true,
  imports: [
  ],
  templateUrl: './book-titles.component.html',
  styleUrl: './book-titles.component.css'
})
export class BookTitlesComponent {

    @Input() books: Book[]=[];
    @Output() selected=new  EventEmitter<Book>();
}
