import { Component } from "@angular/core";

@Component({
    standalone: true, //no modules needed
    selector: 'books-app',
    template:`
        <h1>{{title}}</h1>
        <p>{{tagLine}}</p>
        <p>{{time}}</p>
        <hr/>
        <h2>Author List</h2>
        `,
    styles:[
        `h1{
            color:darkred;
            text-shadow: -2px -2px 1px gray;
        }`
    ]
})
export class BooksAppComponent{
    title="World Wide Books";
    public tagLine=`Official Home Page of All the books`;
    time= new Date().toLocaleTimeString(); 

    constructor(){
        setInterval(()=>{
            this.time= new Date().toLocaleTimeString();
        },1000);
    }
}
 
