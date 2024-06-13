import { bootstrapApplication } from '@angular/platform-browser';
import { BooksAppComponent } from './books-app.component';


bootstrapApplication(BooksAppComponent)
  .catch((err) => console.error(err));
