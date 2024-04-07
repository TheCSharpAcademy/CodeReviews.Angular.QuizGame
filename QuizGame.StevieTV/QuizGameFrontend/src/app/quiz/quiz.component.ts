import { NgIf } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from "@angular/router";
import { Quiz } from "../quiz.model";
import { QuizService } from "../quiz.service";
import { QuizzesComponent } from "../quizzes/quizzes.component";

@Component({
  selector: 'app-quiz',
  standalone: true,
  imports: [
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    NgIf,
    QuizzesComponent,
    RouterLink,
  ],
  templateUrl: './quiz.component.html',
  styleUrl: './quiz.component.css'
})
export class QuizComponent implements OnInit {
  quiz: Quiz = {
    id: 0,
    name: ''
  };

  emptyQuiz: Quiz = {
    id: 0,
    name: ''
  };

  constructor(private quizService: QuizService) {
  }

  ngOnInit() {
    this.quizService.quizSelected.subscribe(quiz => this.quiz = quiz)
  }

  addQuiz() {
    this.quizService.addQuiz(this.quiz).subscribe(res =>
      console.log(res));
  }

  editQuiz() {
    this.quizService.editQuiz(this.quiz).subscribe(res => console.log(res))
  }

  deleteQuiz() {
    this.quizService.deleteQuiz(this.quiz).subscribe(res => console.log(res))
  }

}
