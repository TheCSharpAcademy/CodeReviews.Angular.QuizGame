import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quiz-dialog',
  templateUrl: './quiz-dialog.component.html',
  styleUrls: ['./quiz-dialog.component.css'],
})
export class QuizDialogComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public quizData: any,
    private dialogRef: MatDialogRef<QuizDialogComponent>,
    private router: Router
  ) {}

  onDialogClose() {
    this.dialogRef.close();
    this.router.navigate(['/']);
  }
}
