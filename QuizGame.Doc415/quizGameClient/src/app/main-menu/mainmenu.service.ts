import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MainmenuService {

  constructor() { }

  inGameState=signal<boolean>(false);
  inStatsState=signal<boolean>(false);
  
}
