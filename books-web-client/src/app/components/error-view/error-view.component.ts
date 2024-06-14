import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-error-view',
  standalone: true,
  imports: [],
  templateUrl: './error-view.component.html',
  styles: [
    `
    img{
      width:400px;
    }
    div{
      justify-content:center;
      align-items:center;
      
    }
    `
  ]
})
export class ErrorViewComponent {
  @Input() title:String="Not Found";
  @Input() message: String=`Sorry We couldn't find what you were looking for.
  We have notified our admin!`;
}
