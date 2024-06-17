import { Component } from '@angular/core';
import {MatDialogModule} from '@angular/material/dialog';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { inject } from '@angular/core';


@Component({
  selector: 'app-quiz-dialog',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './quiz-dialog.component.html',
  styleUrl: './quiz-dialog.component.css'
})
export class QuizDialogComponent {
  

  

}
