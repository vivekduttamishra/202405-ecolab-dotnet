import { Component, EventEmitter, Input, Output } from "@angular/core";
import { FontAwesomeModule, SizeProp } from "@fortawesome/angular-fontawesome";

import { faArrowCircleUp, faArrowCircleDown } from '@fortawesome/free-solid-svg-icons';

export interface RangeInfo{
    originalValue: number;
    value: number;
    delta: number;
}

@Component({
    standalone: true,
    selector: 'ca-range',
    imports:[
        FontAwesomeModule
    ],
    template: `
        <div class='row'>
            <button class='col col-3 btn btn-sm'
                [disabled]='value<=min'
                (click)='updateValue(-1)'
            >
            <fa-icon [icon]='decrementIcon' [size]='size' />
            </button>
            
            <span class='col col-4'>{{value}}</span>

            <button class='col col-3 btn btn-sm'
                [disabled]='value>=max'
                (click)='updateValue(1)'
            >
            <fa-icon [icon]='incrementIcon' [size]='size'/>
            </button>
        </div>
    `,

    styles: [`
        div{
            min-width:120px;
            
            margin:5px;
        }
    `]

})
export class CaRangeComponent {

    incrementIcon= faArrowCircleUp;
    decrementIcon= faArrowCircleDown;
    @Input() size:SizeProp='2x';

    @Input() min=0;
    @Input() max=100;
    @Input() delta=1;
    
    @Input() value:number=10;
    @Output() valueChange=new EventEmitter<number>();

    @Output() change=new EventEmitter<RangeInfo>();

    // direction +1 or -1 
    updateValue(direction:number){
      console.log(`updateValue(${this.value} ${this.delta}) called`);
      var newValue= this.value+(this.delta*direction);
      newValue=Math.max(newValue,this.min);
      newValue=Math.min(newValue,this.max);

      var info:RangeInfo={
        originalValue:this.value,
        value:newValue,
        delta:this.delta*direction
      }
      
      this.value=newValue;

      this.change.emit(info);
      this.valueChange.emit(this.value);
    }

}