import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'jsonify',
  standalone: true,
  pure:false
})
export class JsonifyPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    //console.log('value:', value);
    return JSON.stringify(value);
  }

}
  