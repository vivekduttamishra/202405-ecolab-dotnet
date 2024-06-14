import { bootstrapApplication } from '@angular/platform-browser';
import { BooksAppComponent } from './app/books-app.component';
import { BooksAppConfiguration } from './app/app.config';


bootstrapApplication(BooksAppComponent,BooksAppConfiguration)
  .catch((err) => console.error(err));
