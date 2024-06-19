import { BookListComponent } from "../books/components/book-list/book-list.component";
import { BookAddComponent } from "../books/components/book-add/book-add.component";
import { BookDetailsComponent } from "../books/components/book-details/book-details.component";
import { AuthorDetailsComponent } from "../authors/components/author-details/author-details.component";
import { AuthorAddComponent } from "../authors/components/author-add/author-add.component";
import { AuthorListComponent } from "../authors/components/author-list/author-list.component";
import { BookManageComponent } from "../books/components/book-manage/book-manage.component";
import { UserRegistrationComponent } from "../users/components/user-registration/user-registration.component";
import { UserLoginComponent } from "../users/components/user-login/user-login.component";

import { Routes } from "@angular/router";
import { HomeComponent } from "./components/home/home.component";
import { ErrorViewComponent } from "./components/error-view/error-view.component";
//let us export a list of routes
export const appRoutes: Routes=[

    
    //{path:'', redirectTo: '/books/list', pathMatch: 'full'},
    
    {path:'', component: HomeComponent},

    {path: 'books/list', component: BookListComponent},
    {path: 'books/add', component: BookAddComponent},
    {path: 'books/manage', component: BookManageComponent},
    {path: 'books/:id', component: BookDetailsComponent},
    {path: 'authors/list', component: AuthorListComponent},
    {path: 'authors/add', component: AuthorAddComponent},
    {path: 'authors/:id', component: AuthorDetailsComponent},
    {path: 'user/register', component: UserRegistrationComponent},
    {path: 'user/login', component:UserLoginComponent},
    {path: 'error', component:ErrorViewComponent},
    
    {path:'**', component:ErrorViewComponent},

]