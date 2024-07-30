import { Component, ViewChild } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { Game } from '../game.model';
import { QuizServiceService } from '../quiz-service.service';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { Quiz } from '../quiz.model';

@Component({
  selector: 'app-scorehistory',
  standalone: true,
  imports: [MatTableModule, MatDialogModule, MatPaginatorModule, CommonModule, MatPaginator],
  templateUrl: './scorehistory.component.html',
  styleUrl: './scorehistory.component.css'
})
export class ScorehistoryComponent {
  quizzes: Quiz[] = [];
  dataSource = new MatTableDataSource<Game>();
  displayedColumns: string[] = ['id', 'playerName', 'score', 'quizId']

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private quizService: QuizServiceService, public dialog: MatDialog, public dialogRef: MatDialogRef<ScorehistoryComponent>,
    @Inject(MAT_DIALOG_DATA) public games: Game[]){
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit() {
    this.quizService.getQuizs().subscribe((quizzesData: Quiz[]) => {
      this.quizzes = quizzesData;
  
      this.quizService.getGames().subscribe((gamesData: Game[]) => {
        const gamesWithQuizNames = gamesData.map(game => ({
          ...game,
          quizName: this.quizzes.find(quiz => quiz.id === game.quizId)?.quizName || 'Unknown'
        }));
  
        this.dataSource.data = gamesWithQuizNames;
      });
    });
  }
  

  
}