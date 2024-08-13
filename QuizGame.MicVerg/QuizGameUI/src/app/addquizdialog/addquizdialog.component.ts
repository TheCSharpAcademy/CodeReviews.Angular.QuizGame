import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { Quiz } from '../quiz.model';
import { Question } from '../question.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, NgModel } from '@angular/forms';


@Component({
  selector: 'app-addquizdialog',
  standalone: true,
  imports: [MatDialogModule, MatPaginatorModule, MatPaginator, CommonModule, MatFormFieldModule, MatInputModule, MatButtonModule, FormsModule],
  templateUrl: './addquizdialog.component.html',
  styleUrl: './addquizdialog.component.css'
})
export class AddquizdialogComponent {
  currentPageIndex = 0;
  pageSize = 5;
  repeatItems = Array(10).fill(null);
  quizName = '';
  questions: Question[] = [];

  formFields = [
    { question: 'Question 1', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 2', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 3', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 4', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 5', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 6', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 7', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 8', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 9', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''},
    { question: 'Question 10', answer1: '', answer2: '', answer3: '', correctAnswerIndex: ''}
  ]

  submitQuiz(){
    const addQuizPayload = {
      quizName: this.quizName,
      questions: this.formFields.map(field => ({
        quizQuestion: field.question,
        answer1: field.answer1,
        answer2: field.answer2,
        answer3: field.answer3,
        correctAnswerIndex: field.correctAnswerIndex
      }))
    }
    console.log(addQuizPayload);
  }
  
  onPageChange(event: PageEvent) {
    this.currentPageIndex = event.pageIndex;
  }

  get isLastPage(): boolean {
    return this.currentPageIndex + 1 >= Math.ceil(this.formFields.length / this.pageSize);
  }

}
