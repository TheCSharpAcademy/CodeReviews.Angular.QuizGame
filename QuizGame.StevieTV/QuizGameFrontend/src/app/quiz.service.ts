import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from "rxjs";
import { Question } from './question.model';

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

  getQuestions(){
    let questionUrl = this.baseUrl + '/Question'
    return this.http.get(questionUrl, this.httpOptions);
  }

  selectQuestion(question: Question) {
    this.selectedQuestion.next(question);
  }
}
