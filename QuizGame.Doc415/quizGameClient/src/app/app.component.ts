import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { GameComponent } from './game/game.component';
import { GamesTableComponent } from './games-table/games-table.component';
import { MainmenuService } from './main-menu/mainmenu.service';
import { GameService } from './game/game.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    HeaderComponent,
    MainMenuComponent,
    GameComponent,
    GamesTableComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  constructor(
    public menuService: MainmenuService,
    public gameService: GameService
  ) {}
  title = 'quizGameClient';
  get isGameState() {
    return this.menuService.inGameState();
  }

  get isStatsState() {
    return this.menuService.inStatsState();
  }

}
