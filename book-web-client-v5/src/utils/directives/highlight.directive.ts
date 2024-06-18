import { Directive, ElementRef, Input, OnInit } from '@angular/core';

interface HightLightOptions{
  backgroundColor?:string;
  foregroundColor?:string;
  size?:number;
}


@Directive({
  selector: '[ca-highlight]',
  standalone: true
})
export class HighlightDirective implements OnInit{

  constructor(
    private el: ElementRef
  ) { }

  

  @Input("ca-highlight") options?:string|HightLightOptions;
  @Input("foreground") foregroundColor?:string;
  @Input("highlight-size") size?:number;

  default_options:HightLightOptions={
    backgroundColor:"yellow",
    
  };

  ngOnInit(): void {

    

     if(!this.options){
        this.options=this.default_options;
     }
     else if(typeof this.options === "string"){
        this.options={
          ...this.default_options,
          backgroundColor:this.options
        };
        if(this.foregroundColor)
          this.options.foregroundColor=this.foregroundColor;
      
        if(this.size)
          this.options.size=this.size;
      }
      else{
        this.options={
         ...this.default_options,
         ...this.options
        };
       
      }

      

      this.el.nativeElement.style.background=this.options.backgroundColor;

      if(this.options.foregroundColor) {
        this.el.nativeElement.style.color=this.options.foregroundColor;
      }

      if(this.options.size){
        this.el.nativeElement.style.fontSize=this.options.size+"px";
      }
  }

}
