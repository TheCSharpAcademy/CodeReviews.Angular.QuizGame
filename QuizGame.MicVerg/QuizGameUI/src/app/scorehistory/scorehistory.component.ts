import { Component } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { Game } from '../game.model';
import { QuizServiceService } from '../quiz-service.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MainmenuComponent } from '../mainmenu/mainmenu.component';
import { firstValueFrom } from 'rxjs';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';

@Component({
  selector: 'app-scorehistory',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './scorehistory.component.html',
  styleUrl: './scorehistory.component.css'
})
export class ScorehistoryComponent {

  displayedColumns: string[] = ['id', 'playerName', 'score', 'quizId']

  constructor(private quizService: QuizServiceService, public dialog: MatDialog, public dialogRef: MatDialogRef<ScorehistoryComponent>,
    @Inject(MAT_DIALOG_DATA) public games: Game[]){
  }

  
}
