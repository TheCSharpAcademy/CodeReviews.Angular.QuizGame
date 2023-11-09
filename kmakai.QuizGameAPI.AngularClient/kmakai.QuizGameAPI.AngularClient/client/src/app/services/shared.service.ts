import { EventEmitter, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  public quizEvent = new EventEmitter<any>();

  constructor() {}
}
