import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, catchError, finalize, Observable, of } from 'rxjs';
import { Quiz } from '../models/Quiz';
import { url } from '../config/config';
import { ErrorsService } from './errors.service';
import { QuizDetailsDTO } from '../models/DTOs/QuizDetailsDTO';
import { QuizReqDTO } from '../models/DTOs/QuizReqDTO';

@Injectable({
  providedIn: 'root',
})
export class QuizzesService {
  private isLoadingSubject = new BehaviorSubject<boolean>(false);
  isLoading$: Observable<boolean> = this.isLoadingSubject.asObservable();

  constructor(
    private http: HttpClient,
    private errorsService: ErrorsService,
  ) {}

  getQuizzes(): Observable<Quiz[]> {
    this.errorsService.clear();
    this.isLoadingSubject.next(true);
    return this.http.get<Quiz[]>(url + 'Quizzes').pipe(
      catchError((error) => of(this.handleError(error))),
      finalize(() => this.isLoadingSubject.next(false)),
    );
  }

  getQuiz(id: number): Observable<QuizDetailsDTO> {
    this.errorsService.clear();
    this.isLoadingSubject.next(true);
    return this.http.get<QuizDetailsDTO>(url + 'Quizzes/' + id).pipe(
      catchError((error) => of(this.handleError(error))),
      finalize(() => this.isLoadingSubject.next(false)),
    );
  }

  addQuiz(quiz: QuizReqDTO): Observable<QuizReqDTO> {
    this.errorsService.clear();
    this.isLoadingSubject.next(true);
    return this.http.post<QuizReqDTO>(url + 'Quizzes', quiz).pipe(
      catchError((error) => of(this.handleError(error))),
      finalize(() => this.isLoadingSubject.next(false)),
    );
  }

  deleteQuiz(id: number): Observable<Quiz> {
    this.errorsService.clear();
    this.isLoadingSubject.next(true);
    return this.http.delete<Quiz>(url + 'Quizzes/' + id).pipe(
      catchError((error) => of(this.handleError(error))),
      finalize(() => this.isLoadingSubject.next(false)),
    );
  }

  private handleError(error: HttpErrorResponse): any {
    if (error.status === 0) {
      this.errorsService.add("Couldn't connect to Quizzes API.");
    }
    if (error.status === 500) {
      this.errorsService.add('Something went wrong. Try again later.');
    }
    if (error.status === 404) {
      this.errorsService.add('Quizzes not found.');
    }
    return;
  }
}
