import { NgIf } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Question } from '../question.model';
import { QuizService } from '../quiz.service';

@Component({
  selector: 'app-add-question',
  standalone: true,
  imports: [
    MatCardModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    NgIf,
  ],
  templateUrl: './add-question.component.html',
  styleUrl: './add-question.component.css',
})
export class AddQuestionComponent implements OnInit{
  newQuestion: Question = {
    id: 0,
    questionPrompt: '',
    answer1: '',
    answer2: '',
    answer3: '',
    correctAnswer: 1,
    QuizId: 1
  };

  emptyQuestion: Question = {
    id: 0,
    questionPrompt: '',
    answer1: '',
    answer2: '',
    answer3: '',
    correctAnswer: 1,
    QuizId: 1
  };

  constructor(private quizService: QuizService) {}

  ngOnInit() {
    this.quizService.questionSelected.subscribe(question => this.newQuestion = question)
  }

  addQuestion() {
    console.log(this.newQuestion.questionPrompt + this.newQuestion.answer1 + this.newQuestion.answer2 + this.newQuestion.answer3 + this.newQuestion.correctAnswer);
    this.quizService.addQuestion(this.newQuestion).subscribe(res =>
      console.log(res));
  }

  editQuestion() {
    this.quizService.editQuestion(this.newQuestion).subscribe(res => console.log(res));
  }

  deleteQuestion() {
    this.quizService.deleteQuestion(this.newQuestion).subscribe(res => console.log(res));
  }
}
