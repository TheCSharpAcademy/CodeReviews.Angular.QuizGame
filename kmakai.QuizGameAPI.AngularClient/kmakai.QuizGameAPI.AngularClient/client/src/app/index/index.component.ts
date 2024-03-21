import { Component, ViewChild } from '@angular/core';
import { QuizappService } from '../services/quizapp.service';
import { SharedService } from '../services/shared.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
})
export class IndexComponent {
  displayedColumns: string[] = ['playerName', 'score', 'quizName'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  quizzes: any;
  games: any = [];
  constructor(
    private quizService: QuizappService,
    private sharedService: SharedService
  ) {}

  ngOnInit() {
    this.getQuizzes();
    this.getGames();
  }

  getQuizzes() {
    this.quizService.getQuizzes().subscribe((response) => {
      this.quizzes = response;
    });
  }

  getGames() {
    this.quizService.getGames().subscribe((response) => {
      this.games = (response as Array<any>).map((game: any) => {
        return {
          playerName: game.playerName,
          score: game.score,
          quizName: this.quizzes.find((x: any) => x.id === game.quizId).name,
        };
      });
      console.log(this.games);
      this.dataSource = new MatTableDataSource(this.games);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  deleteQuiz(quizId: number) {
    this.quizService.deleteQuiz(quizId).subscribe((response) => {
      this.getQuizzes();
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
