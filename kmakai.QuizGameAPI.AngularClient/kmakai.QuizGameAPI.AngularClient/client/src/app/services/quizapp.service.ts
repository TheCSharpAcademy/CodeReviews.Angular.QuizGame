import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class QuizappService {
  apiUrl = 'https://localhost:7154/api/';
  constructor(private http: HttpClient) {}

  postQuiz(quizObj: any) {
    console.log(quizObj);
    return this.http.post(this.apiUrl + 'quiz', quizObj);
  }

  postQuestions(
    questionsArray: {
      Text: string;
      Answer: string;
      Option1: string;
      Option2: string;
      Option3: string;
      Option4: string;
      QuizId: number;
    }[]
  ) {
    questionsArray = questionsArray.map((q) => {
      return {
        ...q,
        Answer: q.Answer.toString(),
        Option1: q.Option1.toString(),
        Option2: q.Option2.toString(),
        Option3: q.Option3.toString(),
        Option4: q.Option4.toString(),
        id: 0,
      };
    });
    console.log(questionsArray);
    return this.http.post(this.apiUrl + 'quiz/questions', questionsArray, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*', // Required for CORS support to work
      },
    });
  }

  getQuizzes() {
    return this.http.get(this.apiUrl + 'quiz/quizzes');
  }

  getQuiz(quizId: number) {
    return this.http.get(this.apiUrl + 'quiz/' + quizId);
  }

  getQuestions(quizId: number) {
    return this.http.get(this.apiUrl + 'quiz/questions/' + quizId);
  }

  getGames() {
    return this.http.get(this.apiUrl + 'game/games');
  }

  submitAnswers(submitObj: any) {
    return this.http.post(this.apiUrl + 'game/submit', submitObj);
  }

  deleteQuiz(quizId: number) {
    return this.http.delete(this.apiUrl + 'quiz/' + quizId);
  }
}
