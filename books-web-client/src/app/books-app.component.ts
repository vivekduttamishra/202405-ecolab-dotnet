import { Component } from "@angular/core";
import { AppHeaderComponent } from "./components/app-header/app-header.component";
import { AppFooterComponent } from "./components/app-footer/app-footer.component";
import { RouterOutlet } from "@angular/router";


@Component({
    standalone: true, //no modules needed
    selector: 'books-app',
    template:`
        <div class=''>
            <app-header title="World Wide Books"></app-header>
            <div class='container'>
                <router-outlet></router-outlet>
            </div>
            <app-footer url='http://conceptarchitect.in' text="Concept Architect" ></app-footer>
        </div>
        `,
    styles:[
        `.container{
            margin-bottom:60px;
        }`
    ],
    imports:[
        RouterOutlet,
        AppHeaderComponent,
        AppFooterComponent,
       
    ]
  
        
})
export class BooksAppComponent{
    
}
 
