import { Component, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import { QuizServiceService } from '../quiz-service.service';
import { Question } from '../question.model';
import { QuizDialogComponent } from '../quiz-dialog/quiz-dialog.component';
import { MatDialog } from '@angular/material/dialog';


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

  ngOnInit() {
    this.fetchQuestionsByQuizId(2);
  }

  fetchQuestionsByQuizId(Id: number | string) {
    this.quizService.getQuestionsByQuizId(Id).subscribe(questions => { this.questions = questions;
      console.log(this.questions);
    });
  }

  openDialog() {
    this.dialog.open(QuizDialogComponent);
  }
}
