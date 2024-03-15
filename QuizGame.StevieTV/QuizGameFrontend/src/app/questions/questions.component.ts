import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { QuizService } from '../quiz.service';

@Component({
  selector: 'app-questions',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatListModule],
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css'],
})
export class QuestionsComponent implements OnInit {

  questions: any;
  constructor(public quizService: QuizService) {}

  ngOnInit() {
    this.quizService.getQuestions().subscribe(res => this.questions = res);
  }



}
