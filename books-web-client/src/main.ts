import { bootstrapApplication } from '@angular/platform-browser';
import { BooksAppComponent } from './books-app.component';
import { AuthorDetailsComponent } from './author-details/author-details.component';


bootstrapApplication(AuthorDetailsComponent)
  .catch((err) => console.error(err));
