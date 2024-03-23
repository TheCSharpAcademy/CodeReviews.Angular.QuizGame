import { NgForOf } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatListModule } from "@angular/material/list";
import { Game } from "../game.model";
import { QuizService } from "../quiz.service";
import { ActivatedRoute, Router } from "@angular/router";
import { MatExpansionModule } from '@angular/material/expansion';
import { MatRadioModule } from '@angular/material/radio';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-playquiz',
  standalone: true,
  imports: [
    MatCardModule,
    MatListModule,
    MatExpansionModule,
    NgForOf,
    MatButtonModule,
    MatRadioModule,
    MatInputModule,
    FormsModule,
    MatSnackBarModule
  ],
  templateUrl: './playquiz.component.html',
  styleUrl: './playquiz.component.css'
})
export class PlayquizComponent implements OnInit {

  questions: any;
  quizId: number | undefined;
  step = 0;
  game: Game =
    {
      id: 0,
      QuizId: 0,
      playerName: '',
      potentialTotal: 0,
      score: 0
    };

  constructor(public quizService: QuizService, private router: Router, private route: ActivatedRoute, private _snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.quizId = Number(this.route.snapshot.paramMap.get('quizId'));
    this.quizService.getQuestions(this.quizId).subscribe(res => {
      this.questions = res

      // @ts-ignore
      this.questions.forEach(q => {
        q.answers = [q.answer1, q.answer2, q.answer3]
        shuffle(q.answers)

      })
      this.game.potentialTotal = this.questions.length;

    });
    this.game.QuizId = this.quizId;
  }

  setStep(index: number) {
    this.step = index;
  }

  nextStep() {
    this.step++;
  }

  finishQuiz() {
    this.game.score = 0;
    // @ts-ignore
    this.questions.forEach(q => {
      switch (q.correctAnswer) {
        case 1:
          if (q.selectedAnswer == q.answer1)
            this.game.score++;
          break;
        case 2:
          if (q.selectedAnswer == q.answer1)
            this.game.score++;
          break;
        case 3:
          if (q.selectedAnswer == q.answer1)
            this.game.score++;
          break;
      }
    })
    console.log(this.game)
    this.quizService.addGame(this.game).subscribe(res => console.log(res));
    let message = `Well Done ${this.game.playerName} - you scored ${this.game.score}/${this.game.potentialTotal}`
    this._snackBar.open(message, "OK")
      .onAction()
      .subscribe(() => this.router.navigateByUrl('/'));
  }
}

function shuffle(a: any) {
  for (let i = a.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [a[i], a[j]] = [a[j], a[i]];
  }
  return a;
}
