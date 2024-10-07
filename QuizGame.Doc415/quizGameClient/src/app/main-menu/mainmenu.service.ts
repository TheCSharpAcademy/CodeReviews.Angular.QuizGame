import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MainmenuService {

  constructor() { }

  inGameState=signal<boolean>(false);
  inStatsState=signal<boolean>(false);

  startStats(){
    this.inGameState.set(false);
    this.inStatsState.set(true);
  }

  startGame(){
    this.inGameState.set(true);
    this.inStatsState.set(false);
  }

  returnMainMenu(){
    this.inGameState.set(false);
    this.inStatsState.set(false);
  }
  
}
