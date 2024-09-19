import { inject, Injectable, signal } from '@angular/core';
import { Question } from './question.model';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
@Injectable({
  providedIn: 'root',
})
export class TrivaDbServiceService {
  private _snackBar = inject(MatSnackBar);
  private httpClient = inject(HttpClient);
  url = 'https://opentdb.com/api.php?amount=10&type=multiple';
  questionsInQuiz = signal<Question[]>([]);
  isLoaded = signal<boolean>(false);
  response?: string;
  constructor() {}


  async getQuestionsFromTriviaDbAsync() {
    this.isLoaded.set(false);
    try {
        const query = this.httpClient
        .get<{ response_code: number; results: Question[] }>(this.url)
      const resData=await lastValueFrom(query); 
      
      this.questionsInQuiz.set(resData!.results);
      this.shuffleAnswers();
      this.isLoaded.set(true);
    } catch {
      this._snackBar.open('Can not connect to TrivaDB','Dismiss', {
        duration: 2000,
      })     
      console.log("error");
    }
  }

  shuffleAnswers() {
    let tempQuestions=[...this.questionsInQuiz()]
    for (let question of tempQuestions) {
        question.all_answers=[];
        question.all_answers = question.incorrect_answers.concat([
        question.correct_answer,
      ]);
      console.log(question.all_answers);
      question.all_answers = shuffleArray(question.all_answers);
      console.log(question.all_answers);
    }
    this.questionsInQuiz.set(tempQuestions);
  }
}

function shuffleArray(array: string[]) {
  for (let i = array.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    [array[i], array[j]] = [array[j], array[i]];
  }
  return array;
}
