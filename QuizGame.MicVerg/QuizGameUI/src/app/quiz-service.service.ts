import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, map, catchError } from 'rxjs';
import { Quiz } from './quiz.model';
import { Game } from './game.model';
import { Question } from './question.model';

@Injectable({
  providedIn: 'root'
})
export class QuizServiceService {
  private apiQuestionsUrl: string = 'https://localhost:7140/api/questions?quizId=';
  private apiGamesUrl: string = 'https://localhost:7140/api/games/';
  private apiQuizsUrl: string = 'https://localhost:7140/api/quizs/';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getQuestionsByQuizId(Id: number | string): Observable<Question[]>{
    return this.http.get<Question[]>(`${this.apiQuestionsUrl}${Id}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.error('Error response:', error.error);
      return of(result as T);
    };
  }
}
