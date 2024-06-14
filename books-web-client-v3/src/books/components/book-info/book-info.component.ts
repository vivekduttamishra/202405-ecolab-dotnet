import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Book } from '../../models/book.model';

@Component({
  selector: 'book-info',
  standalone: true,
  imports: [],
  templateUrl: './book-info.component.html',
  styleUrl: './book-info.component.css'
})
export class BookInfoComponent {

  @Input() selectedBook?: Book;

  @Output() delete=new EventEmitter();
}
