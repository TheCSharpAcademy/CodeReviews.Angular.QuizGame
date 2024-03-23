import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from "rxjs";
import { Game } from "./game.model";
import { Question } from './question.model';
import { Quiz } from "./quiz.model";

@Injectable({
  providedIn: 'root',
})
export class QuizService {
  private baseUrl = 'http://localhost:5229/api';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  private selectedQuestion = new Subject<any>();
  questionSelected = this.selectedQuestion.asObservable();

  private selectedQuiz = new Subject<any>();
  quizSelected = this.selectedQuiz.asObservable();

  constructor(private http: HttpClient) {}

  addQuestion(question: Question) {
    let questionUrl = this.baseUrl + '/Question'
    return this.http.post<Question>(questionUrl, question, this.httpOptions);
  }

  editQuestion(question: Question) {
    let questionUrl = this.baseUrl + '/Question/' + question.id;
    return this.http.put<Question>(questionUrl, question, this.httpOptions);
  }

  deleteQuestion(question: Question) {
    let questionUrl = this.baseUrl + '/Question/' + question.id;
    return this.http.delete<Question>(questionUrl);
  }

  getQuestions(quizId: number){
    let questionUrl = this.baseUrl + '/Questions/' + quizId
    return this.http.get(questionUrl, this.httpOptions);
  }

  selectQuestion(question: Question) {
    this.selectedQuestion.next(question);
  }

  addQuiz(quiz: Quiz) {
    let quizUrl = this.baseUrl + '/Quiz'
    return this.http.post<Quiz>(quizUrl, quiz, this.httpOptions);
  }

  editQuiz(quiz: Quiz) {
    let quizUrl = this.baseUrl + '/Quiz/' + quiz.id;
    return this.http.put<Quiz>(quizUrl, quiz, this.httpOptions);
  }

  deleteQuiz(quiz: Quiz) {
    let quizUrl = this.baseUrl + '/Quiz/' + quiz.id;
    return this.http.delete<Quiz>(quizUrl);
  }

  getQuizzes(){
    let quizUrl = this.baseUrl + '/Quiz'
    return this.http.get(quizUrl, this.httpOptions);
  }

  getQuiz(id: number){
    let quizUrl = this.baseUrl + '/Quiz/' + id;
    return this.http.get(quizUrl, this.httpOptions);
  }
  selectQuiz(quiz: Quiz) {
    this.selectedQuiz.next(quiz);
  }

  addGame(game: Game){
    let gameUrl = this.baseUrl + '/Game'
    return this.http.post<Game>(gameUrl, game, this.httpOptions);
  }

  getGames() {
    let gameUrl = this.baseUrl + '/Game'
    return this.http.get<Game>(gameUrl, this.httpOptions);
  }
}
