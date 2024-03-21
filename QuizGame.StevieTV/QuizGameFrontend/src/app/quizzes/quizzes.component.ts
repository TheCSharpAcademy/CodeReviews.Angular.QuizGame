import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { QuizService } from '../quiz.service';

@Component({
  selector: 'app-quizzes',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatListModule],
  templateUrl: './quizzes.component.html',
  styleUrl: './quizzes.component.css'
})
export class QuizzesComponent implements OnInit {

  quizzes: any;
  constructor(public quizService: QuizService) {}

  ngOnInit() {
    this.quizService.getQuizzes().subscribe(res => this.quizzes = res);
  }
}
