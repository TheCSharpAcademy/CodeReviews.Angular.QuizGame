import { Component } from '@angular/core';
import {MatDialogModule} from '@angular/material/dialog';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
  MatDialogConfig
} from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { Question } from '../question.model';
import { QuizServiceService } from '../quiz-service.service';
import { CommonModule } from '@angular/common';
import { firstValueFrom } from 'rxjs';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-quiz-dialog',
  standalone: true,
  imports: [MatDialogModule, CommonModule],
  templateUrl: './quiz-dialog.component.html',
  styleUrl: './quiz-dialog.component.css'
})
export class QuizDialogComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public questions: Question[]) {}
}
  


