import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Book } from "../../models/book.model";
import { CaRangeComponent } from "../../../utils/components/ca-range/ca-range.component";
import { RouterLink } from "@angular/router";
import {  BookService } from "../../services/book-service.service";


@Component({
    standalone:true,
    selector:'book-list',
    templateUrl: './book-list.component.html',
    styleUrls:['./book-list.component.css'],
    imports:[
        CommonModule,
        CaRangeComponent,
        RouterLink
    ]
})
export class BookListComponent implements OnInit{
    
  books: Book[]=[];
   
    constructor(
      private service: BookService

    ){      
  
    }


  ngOnInit(): void {

    this.books=this.service.getAllBooks();
    
  }
    showImages=true;
    imageHeight=120;
    
    toggleImages(){
      this.showImages=!this.showImages;
    }

    
    // logChange(info:RangeInfo){
    //   console.log("parent got",info);
    //   }
      

  //   update(value:number){        
  //     this.imageHeight=value;
  // }
    
}