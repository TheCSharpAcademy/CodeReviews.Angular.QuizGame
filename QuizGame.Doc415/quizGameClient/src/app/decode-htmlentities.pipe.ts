import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'decodeHTMLEntities',
  standalone: true
})
export class DecodeHTMLEntitiesPipe implements PipeTransform {

  transform(value: string): string {
    if (!value) return value;
    const textarea = document.createElement('textarea');
    textarea.innerHTML = value;
    return textarea.value;
  }

}
