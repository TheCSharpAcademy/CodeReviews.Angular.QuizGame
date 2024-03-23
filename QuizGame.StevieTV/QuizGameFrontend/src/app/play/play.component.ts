import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import { QuizService } from "../quiz.service";
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-play',
  standalone: true,
  imports: [
    MatCardModule,
    MatListModule,
    CommonModule,
    MatPaginatorModule
  ],
  templateUrl: './play.component.html',
  styleUrl: './play.component.css'
})
export class PlayComponent implements OnInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  quizzes: any;
  pagedQuizzes: any;
  dataLength: number = 0;

  constructor(public quizService: QuizService ) {
  }

  ngOnInit() {
    this.quizService.getQuizzes().subscribe(res => {
      this.quizzes = res
      this.pagedQuizzes = this.quizzes.slice(0,5);
      this.pagedQuizzes.paginator = this.paginator;
      this.dataLength = this.quizzes.length;
    });
  }

  OnPageChange(event: PageEvent) {
    let from = event.pageIndex * event.pageSize;
    let to = from + event.pageSize;
    if (to > this.dataLength) {
      to = this.dataLength;
    }
    this.pagedQuizzes = this.quizzes.slice(from, to);
  }
}
