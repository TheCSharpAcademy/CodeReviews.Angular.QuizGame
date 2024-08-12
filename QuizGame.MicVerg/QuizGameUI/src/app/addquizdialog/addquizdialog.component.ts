import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { Quiz } from '../quiz.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-addquizdialog',
  standalone: true,
  imports: [MatDialogModule, MatPaginatorModule, MatPaginator, CommonModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './addquizdialog.component.html',
  styleUrl: './addquizdialog.component.css'
})
export class AddquizdialogComponent {

  questionsCount = Array.from({length: 10}, (_, i) => i + 1);

  submitQuiz(){

  }
}
