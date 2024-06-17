import { Component, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import { QuizServiceService } from '../quiz-service.service';
import { Question } from '../question.model';


@Component({
  selector: 'app-mainmenu',
  standalone: true,
  imports: [MatButtonModule, MatCardModule, MatIconModule],
  templateUrl: './mainmenu.component.html',
  styleUrl: './mainmenu.component.css'
})
export class MainmenuComponent {

  questions: Question[] = [];

  constructor(private quizService: QuizServiceService){
  }

  fetchQuestionsByQuizId(Id: number | string) {
    this.quizService.getQuestionsByQuizId(Id).subscribe(questions => { this.questions = questions;
      console.log(this.questions);
    });
  }
}
