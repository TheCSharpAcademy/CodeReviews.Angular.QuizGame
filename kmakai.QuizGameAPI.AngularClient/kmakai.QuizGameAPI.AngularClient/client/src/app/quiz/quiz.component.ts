import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { Observable, merge, of } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';
import { QuizappService } from '../services/quizapp.service';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from '../services/shared.service';
import { MatDialog } from '@angular/material/dialog';
import { QuizDialogComponent } from '../quiz-dialog/quiz-dialog.component';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css'],
})
export class QuizComponent {
  quiz: any = {};
  dataSource!: any[];
  dataSize: number = 10;
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(
    private quizService: QuizappService,
    private route: ActivatedRoute,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.getQuiz(this.route.snapshot.params['quizId']);
  }

  getQuiz(quizId: number) {
    this.quizService.getQuiz(quizId).subscribe((response) => {
      this.quiz = response;
      console.log(this.quiz);
    });

    if (this.quiz) {
      this.quizService.getQuestions(quizId).subscribe((response) => {
        this.quiz.questions = response;
        if (this.quiz.questions) this.linkListToPaginator();
      });
    }
  }

  onAnswer(question: any, answer: any) {
    question.userAnswer = answer;
    console.log(question);
    console.log(this.quiz.questions);
  }

  onSubmit() {
    if (this.quiz.questions.find((q: any) => q.userAnswer == null)) {
      alert('Please answer all questions before submitting.');
      return;
    }
    const playerName = prompt('Please enter your name.');
    console.log({
      playerName,
      quizId: this.quiz.id,
      answers: this.quiz.questions,
    });

    this.quizService
      .submitAnswers({
        playerName,
        quizId: this.quiz.id,
        answers: this.quiz.questions,
      })
      .subscribe((response) => {
        console.log(response);

        this.dialog.open(QuizDialogComponent, {
          data: {
            game: response,
            quizId: this.quiz.id,
            answers: this.quiz.questions,
          },
        });
      });
  }

  linkListToPaginator() {
    merge(this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          console.log(this.quiz.questions);

          return of(this.quiz.questions);
        })
      )
      .subscribe((res) => {
        if (res) {
          const from = this.paginator.pageIndex * this.paginator.pageSize;
          const to = from + this.paginator.pageSize;
          console.log(res);
          this.dataSource = res.slice(from, to);
        }
      });
  }
}
