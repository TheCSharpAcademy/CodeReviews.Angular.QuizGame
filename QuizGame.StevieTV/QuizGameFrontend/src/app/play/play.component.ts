import { NgForOf } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import { QuizService } from "../quiz.service";

@Component({
  selector: 'app-play',
  standalone: true,
  imports: [
    MatCardModule,
    MatListModule,
    NgForOf
  ],
  templateUrl: './play.component.html',
  styleUrl: './play.component.css'
})
export class PlayComponent implements OnInit {

  quizzes: any;

  constructor(public quizService: QuizService ) {
  }

  ngOnInit() {
    this.quizService.getQuizzes().subscribe(res => this.quizzes = res);
  }
}
