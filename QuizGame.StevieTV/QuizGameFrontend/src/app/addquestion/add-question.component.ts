import { NgIf } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Question } from '../question.model';
import { QuestionsComponent } from "../questions/questions.component";
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
    QuestionsComponent,
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
    QuizId: 0
  };

  emptyQuestion: Question = {
    id: 0,
    questionPrompt: '',
    answer1: '',
    answer2: '',
    answer3: '',
    correctAnswer: 1,
    QuizId: 0
  };

  constructor(private quizService: QuizService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.newQuestion.QuizId  = Number(this.route.snapshot.paramMap.get('quizId'));
    this.quizService.questionSelected.subscribe(question => this.newQuestion = question)
  }

  addQuestion() {
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
