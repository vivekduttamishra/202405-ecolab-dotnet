import { Component, Input } from '@angular/core';

@Component({
  selector: 'ca-slide-show',
  standalone: true,
  imports: [],
  template: `
    <p>
      <img 
      [src]='selectedImage'
      [style.width.px]='size' />
    </p>
  `,
  styles: `
    img{
      border: 10px solid black;
      padding: 5px;
      border-radius: 10px;
      box-shadow: -5px -5px 5px gray;
    }
  
  `
})
export class CaSlideShowComponent {
  @Input() size:number=400;
  selectedImage='';
  @Input('base-path') basePath:String='/images';
  @Input('min-index') minIndex:number=1;
  @Input('max-index') maxIndex:number=10;
  @Input('image-type') imageType:string=".jpg";
  @Input('interval') interval:number=5000;

  ngOnInit(){
    this.selectImage();
    setInterval(() => {
      this.selectImage();
    }, this.interval);

  }
  selectImage() {
    var index = Math.floor(Math.random() * (this.maxIndex - this.minIndex + 1)) + this.minIndex;
    this.selectedImage = `${this.basePath}${index}${this.imageType}`;
  }
  

}
