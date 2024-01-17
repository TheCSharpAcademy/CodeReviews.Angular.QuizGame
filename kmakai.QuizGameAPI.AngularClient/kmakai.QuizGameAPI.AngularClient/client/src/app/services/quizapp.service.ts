import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class QuizappService {
  apiUrl = 'https://localhost:7154/api/Game/';
  constructor(private http: HttpClient) {}

  getQuizzes() {
    return this.http.get(this.apiUrl + 'quizzes');
  }

  getQuiz(quizId: number) {
    return this.http.get(this.apiUrl + 'quiz/' + quizId);
  }

  getQuestions(quizId: number) {
    return this.http.get(this.apiUrl + 'questions/' + quizId);
  }

  getGames() {
    return this.http.get(this.apiUrl + 'games/');
  }

  submitAnswers(submitObj: any) {
    return this.http.post(this.apiUrl + 'submit', submitObj);
  }

  deleteQuiz(quizId: number) {
    return this.http.delete(this.apiUrl + 'quiz/' + quizId);
  }
}
