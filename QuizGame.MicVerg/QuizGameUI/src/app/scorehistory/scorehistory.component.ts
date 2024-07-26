import { Component } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { Game } from '../game.model';
import { QuizServiceService } from '../quiz-service.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MainmenuComponent } from '../mainmenu/mainmenu.component';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-scorehistory',
  standalone: true,
  imports: [MainmenuComponent],
  templateUrl: './scorehistory.component.html',
  styleUrl: './scorehistory.component.css'
})
export class ScorehistoryComponent {

  games: Game[] = [];

  constructor(private quizService: QuizServiceService, public dialog: MatDialog){
  }

  
}
