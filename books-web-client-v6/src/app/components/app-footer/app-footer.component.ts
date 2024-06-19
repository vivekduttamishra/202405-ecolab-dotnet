import { Component, EventEmitter, Input, Output } from "@angular/core";

export interface RangeInfo{
    originalValue: number;
    value: number;
    delta: number;
}

@Component({
    standalone: true,
    selector: 'app-footer',
   
    template: `
        <footer>
            &copy; <a [href]='url' >{{text}}</a>
        </footer>
    `,

    styles: [`
        footer {
            margin-top:60px;
            position: fixed;
            left: 0;
            min-height: 50px;
            bottom: 0;
            width: 100%;
            background-color: black;
            color: white;
            text-align: center;
            font-size: 1.1em;
            font-weight:bold;
            }

        a, a:visited{
            color:white;
            text-decoration:none;
        }
    `]

})
export class AppFooterComponent{

        @Input() url: string="#";
        @Input() text: string="";
   
}