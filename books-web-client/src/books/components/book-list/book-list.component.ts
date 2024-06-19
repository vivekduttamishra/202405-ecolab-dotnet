import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Book } from "../../models/book.model";
import { CaRangeComponent } from "../../../utils/components/ca-range/ca-range.component";
import { RouterLink } from "@angular/router";
import {  BookService } from "../../services/book-service.service";
import { HighlightDirective } from "../../../utils/directives/highlight.directive";
import { CaLoadingComponent } from "../../../utils/components/ca-loading/ca-loading.component";
import { delay, take, tap } from "rxjs";


@Component({
    standalone:true,
    selector:'book-list',
    templateUrl: './book-list.component.html',
    styleUrls:['./book-list.component.css'],
    imports:[
        CommonModule,
        CaRangeComponent,
        RouterLink,
        CaLoadingComponent,
        HighlightDirective
    ]
})
export class BookListComponent implements OnInit{
    
  
  constructor(
    private service: BookService
    
  ){      
    
  }
  
  books?: Book[];

  ngOnInit(): void {

    this.service
        .getAllBooks()
        .pipe(
          delay(1000),
          tap(console.log)          
        )
        .subscribe({
          next: books=>this.books = books
        });
    
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