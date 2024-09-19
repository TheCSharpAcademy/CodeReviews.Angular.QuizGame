import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { GamesTableComponent } from '../games-table/games-table.component';
import { type Question } from '../question.model';
import { DecodeHTMLEntitiesPipe } from '../decode-htmlentities.pipe';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-game-details-dialog',
  standalone: true,
  imports: [
    MatButtonModule,
    MatDialogActions,
    MatDialogClose,
    MatDialogTitle,
    MatDialogContent,
    DecodeHTMLEntitiesPipe,
    MatTableModule
  ],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './game-details-dialog.component.html',
  styleUrl: './game-details-dialog.component.scss',
})
export class GameDetailsDialogComponent {
  readonly dialogRef = inject(MatDialogRef<GamesTableComponent>);
  displayedColumns: string[] = ['Question', 'Category', 'Answered'];
  questions: Question[] = inject(MAT_DIALOG_DATA).questions;
  wrongAnsweredQuestions: Question[] =
    inject(MAT_DIALOG_DATA).wrongAnsweredQuestions;
  wrongAnswerIds = this.wrongAnsweredQuestions.map((wrong) => wrong.id);
  
  
}
