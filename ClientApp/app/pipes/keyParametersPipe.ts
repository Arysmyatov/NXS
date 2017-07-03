import { Pipe } from '@angular/core';

// Tell Angular2 we're creating a Pipe with TypeScript decorators
@Pipe({
  name: 'KeyParameterPipe'
})
export class KeyParameterPipe {
  // Transform is the new "return function(value, args)" in Angular 1.x
  transform(value: any[], filter: Object) {
    // ES6 array destructuring
    if(!value) {
        return [];
    }
    return value.filter(variable => {
      return variable.group == filter;
    });
  }
}