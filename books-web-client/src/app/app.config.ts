import { ApplicationConfig } from "@angular/core";
import { provideRouter } from "@angular/router";
import { appRoutes } from "./app.routes";



export const BooksAppConfiguration: ApplicationConfig ={
   providers:[
        provideRouter(appRoutes),
   ]
};


