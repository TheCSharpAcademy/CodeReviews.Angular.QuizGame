import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { ActivatedRoute } from "@angular/router";
import { QuizService } from '../quiz.service';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-questions',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatListModule, MatPaginatorModule],
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css'],
})
export class QuestionsComponent implements OnInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  questions: any;
  pagedQuestions: any;
  dataLength: number = 0;
  constructor(public quizService: QuizService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    let quizId = Number(this.route.snapshot.paramMap.get('quizId'));
    this.quizService.getQuestions(quizId).subscribe(res => {
      this.questions = res;
      this.pagedQuestions = this.questions.slice(0,5);
      this.pagedQuestions.paginator = this.paginator;
      this.dataLength = this.questions.length;
    });
  }

  OnPageChange(event: PageEvent) {
    let from = event.pageIndex * event.pageSize;
    let to = from + event.pageSize;
    if (to > this.dataLength) {
      to = this.dataLength;
    }
    this.pagedQuestions = this.questions.slice(from, to);
  }
}
