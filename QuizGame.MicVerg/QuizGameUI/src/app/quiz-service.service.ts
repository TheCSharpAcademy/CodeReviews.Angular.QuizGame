import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QuizServiceService {
  private apiQuestionsUrl: string = 'https://localhost:7140/api/questions/';
  private apiGamesUrl: string = 'https://localhost:7140/api/games/';
  private apiQuizsUrl: string = 'https://localhost:7140/api/quizs/';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }
}
