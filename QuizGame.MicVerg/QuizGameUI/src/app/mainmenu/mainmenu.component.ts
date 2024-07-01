import { Component, Inject, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import { QuizServiceService } from '../quiz-service.service';
import { Question } from '../question.model';
import { QuizDialogComponent } from '../quiz-dialog/quiz-dialog.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { firstValueFrom } from 'rxjs';


@Component({
  selector: 'app-mainmenu',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, MatIconModule, QuizDialogComponent],
  templateUrl: './mainmenu.component.html',
  styleUrl: './mainmenu.component.css'
})
export class MainmenuComponent {

  questions: Question[] = [];

  constructor(private quizService: QuizServiceService, public dialog: MatDialog){
  }
  async openQuestionsDialog(quizId: number | string) {
    try {
      const questions$ = this.quizService.getQuestionsByQuizId(quizId);
      const questions = await firstValueFrom(questions$);

      const dialogConfig = new MatDialogConfig();
      dialogConfig.height = '75%';
      dialogConfig.width = '80%';
      dialogConfig.data = questions;
      dialogConfig.panelClass = 'custom-dialog-container';

      this.dialog.open(QuizDialogComponent, dialogConfig);
    } catch (error) {
      console.error('Failed to fetch questions:', error);
    }
  }
}

