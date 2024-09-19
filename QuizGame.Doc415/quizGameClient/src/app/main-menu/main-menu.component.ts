import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import { MainmenuService } from './mainmenu.service';

@Component({
  selector: 'app-main-menu',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './main-menu.component.html',
  styleUrl: './main-menu.component.scss'
})
export class MainMenuComponent {
  constructor(public menuService:MainmenuService){}

  
  startGameState(){
    this.menuService.startGame();
  }

  startStatsState(){
    this.menuService.startStats();
    }
}
