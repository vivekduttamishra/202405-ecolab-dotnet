import { ApplicationConfig } from "@angular/core";
import { provideRouter } from "@angular/router";
import { appRoutes } from "./app.routes";
import { SimpleAuthorService } from "../authors/services/simple-author.service";
import { provideHttpClient } from "@angular/common/http";



export const BooksAppConfiguration: ApplicationConfig ={
   providers:[
        provideRouter(appRoutes),
        provideHttpClient(),
        //SimpleAuthorService
   ]
};


