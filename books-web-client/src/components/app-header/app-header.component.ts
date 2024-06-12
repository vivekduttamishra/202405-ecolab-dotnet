import { Component } from "@angular/core";


@Component({
    standalone:true,
    selector:'app-header',
    templateUrl: './app-header.component.html',
    styleUrls:['./app-header.component.css']
})
export class AppHeaderComponent{
    title="World Wide Books";
    slogan="The Official Home Page of all the books in the world";
    
}