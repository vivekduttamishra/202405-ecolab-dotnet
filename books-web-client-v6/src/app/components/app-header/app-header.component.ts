import { Component, Input } from "@angular/core";
import { RouterLink } from "@angular/router";


@Component({
    standalone:true,
    imports:[
        RouterLink
    ],
    selector:'app-header',
    templateUrl: './app-header.component.html',
    styleUrls:['./app-header.component.css']
})
export class AppHeaderComponent{
    @Input() title="";
    @Input() slogan="The Official Home Page of all the books in the world";
    
}