import { Component } from '@angular/core';
import {MatDialogModule} from '@angular/material/dialog';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
  MatDialogConfig
} from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { Question } from '../question.model';
import { QuizServiceService } from '../quiz-service.service';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { Game } from '../game.model';
import {MatFormFieldModule} from '@angular/material/form-field'; 
import { MatTooltip } from '@angular/material/tooltip';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-quiz-dialog',
  standalone: true,
  imports: [MatInputModule, FormsModule, MatTooltip, MatDialogModule, CommonModule, MatButtonModule, MatPaginatorModule, MatFormFieldModule],
  templateUrl: './quiz-dialog.component.html',
  styleUrl: './quiz-dialog.component.css'
})
export class QuizDialogComponent {
  paginatedQuestions: Question[] = [];
  currentPageIndex = 0;
  isButtonDisabled = false;
  showScoreLabel = false;
  playerName = "";

  constructor(private quizService: QuizServiceService, @Inject(MAT_DIALOG_DATA) public questions: Question[]) {this.updatePaginatedQuestions(this.currentPageIndex, 3);}

  selectAnswer(questionId: number, answerId: number) {
    const question = this.questions.find(q => q.id === questionId);

    if (!question) {
      console.error('Question not found');
      return;
    }

    question.isAnswerGiven = true;
    question.selectedAnswerId = answerId;

    const isCorrect = answerId === question.correctAnswer;
    question.selectedAnswerIsCorrect = isCorrect;
  }


  calculateTotalCorrectAnswers(): number {
    let totalCorrect = 0;
    this.questions.forEach(question => {
      if (question.selectedAnswerId === question.correctAnswer) {
        totalCorrect++;
      }
    });
    return totalCorrect;
  }

  
  async submitAnswers() {
    // build game object through selectAnswer?
    // post game object
    this.isButtonDisabled = true;
    const playerName = this.playerName;
    const quizId = this.questions[0].quizId;

    const correctAnswersCount = this.calculateTotalCorrectAnswers();
    const game: Game = {
      playerName: playerName,
      totalAmountOfQuestions: this.questions.length,
      correctAmountOfQuestions: correctAnswersCount,
      quizId: quizId
    };
  
  await this.postGameResults(game);
  this.showScoreLabel = true;
  }


  async postGameResults(game: Game) {
    this.quizService.addGame(game).subscribe({
      next: (success) => {
        console.log('Game added successfully:', success);
      },
      error: (err) => {
        console.error('Error adding game:', err);
      },
      complete: () => {
      }
    });
  }


  get isLastPage(): boolean {
    const pageSize = 3;
    const totalPages = Math.ceil(this.questions.length / pageSize);
    return this.currentPageIndex + 1 === totalPages;
  }


  onPageChange(event: PageEvent) {
    this.currentPageIndex = event.pageIndex;
    this.updatePaginatedQuestions(this.currentPageIndex, event.pageSize);
  }


  updatePaginatedQuestions(pageIndex: number, pageSize: number) {
    const startIdx = pageIndex * pageSize;
    const endIdx = startIdx + pageSize;
    this.paginatedQuestions = this.questions.slice(startIdx, endIdx);
  }
}


