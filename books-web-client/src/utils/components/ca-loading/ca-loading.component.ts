import { Component, Input } from '@angular/core';

@Component({
  selector: 'ca-loading',
  standalone: true,
  imports: [],
  template: `
    <img [src]='loading' [width]='width' />
  `,
  styles: `
    
  `
})
export class CaLoadingComponent {

  @Input() loading= '/images/loading.gif';
  @Input() width=200;
}
