import { inject, Injectable, signal } from '@angular/core';
import { TrivaDbServiceService } from '../triva-db-service.service';
import { type Game } from './game.model';
import { type Quiz } from '../quiz.model';
import { type Question } from '../question.model';
import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class GameService {
  private _snackBar = inject(MatSnackBar);
  private httpClient = inject(HttpClient);
  url = 'https://localhost:7002/api/games';
  wrongAnsweredQuestions: Question[] = [];
  askedQuestions: Question[] = [];
  games = signal<Game[]>([]);
  totalRecords= signal<number>(0);
  defaultPageSize = 3;
  date?: string;

 questionIndex = signal<number>(0);
 wrongAnswers = signal<number>(0);
 selectedAnswer=signal<string|null>(null);
 isCorrect = signal<boolean|null>(null);
 isAnswerSelected=signal<boolean>(false);
 isGameOver=signal<boolean>(false);

  constructor(public trivaDbService: TrivaDbServiceService) {}

  async onGameEnd() {
    this.isGameOver.set(true);
    this.askedQuestions = this.trivaDbService.questionsInQuiz();
    this.date = formatDate(new Date(), 'yyyy-MM-dd', 'en');
    console.log('saving');
    try {
      const query = this.httpClient.post<{
        date: string;
        questions: Question[];
        wrongAnsweredQuestions: Question[];
      }>(this.url, {
        date: this.date,
        questions: this.askedQuestions,
        wrongAnsweredQuestions: this.wrongAnsweredQuestions,
      });
      const response = await lastValueFrom(query);
      this._snackBar.open(`Saved`, 'Dismiss', {
        duration: 2000,
      });
      console.log(response);
      this.resetGame();
    } catch (error) {
      console.log(error);
      this._snackBar.open(`Save failed!`, 'Dismiss', {
        duration: 2000,
      });
    }
  }

  async getGames(
    pageIndex: number = 1,
    pageSize: number = this.defaultPageSize) {
    try {
      const query = this.httpClient.get<{games:Game[];totalRecords:number}>(
        `${this.url}?pageIndex=${pageIndex}&pageSize=${pageSize}`
      );
      var resData = await lastValueFrom(query);
      this.games.set(resData.games)
      this.totalRecords.set(resData.totalRecords)
      this.trivaDbService.isLoaded.set(true)
    } catch (error) {
      this._snackBar.open(`Failed to load data`, 'Dismiss', {
        duration: 2000,
      });
      console.log(error);
    }
  }

  async deleteGame(id:string){
    try{
      const query = this.httpClient.delete(`${this.url}/${id}`);
      var response=await lastValueFrom(query);
      this._snackBar.open(`Game deleted`, 'Dismiss', {
        duration: 2000,
      });
    }
    catch (error) {
      console.log(error);
    }
  }

  resetGame(){
    this.questionIndex.set(0);
    this.wrongAnswers.set(0);
    this.selectedAnswer.set(null);
    this.isCorrect.set(null);
    this.isAnswerSelected.set(false);
    this.wrongAnsweredQuestions=[];
  }
}
