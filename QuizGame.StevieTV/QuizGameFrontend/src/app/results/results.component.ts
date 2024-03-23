import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from "@angular/material/table";
import { MatPaginator, MatPaginatorModule } from "@angular/material/paginator";
import { MatSort, MatSortModule } from "@angular/material/sort";
import { Game } from "../game.model";
import { QuizService } from "../quiz.service";


@Component({
  selector: 'app-results',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatSortModule],
  templateUrl: './results.component.html',
  styleUrl: './results.component.css'
})
export class ResultsComponent {
  displayedColumn: string[] = ['id', 'playerName', 'score', 'percentage', 'quiz'];
  dataSource!: MatTableDataSource<Game>;
  records: any;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private quizService: QuizService) {
    this.quizService.getGames().subscribe(res => {
      console.log(res);
      this.records = res;
      this.dataSource = new MatTableDataSource<Game>(this.records);
      this.dataSource.paginator = this.paginator;
      this.sort.sort({id: 'id', start: 'asc', disableClear: false});
      this.dataSource.sort = this.sort;
    })
  }

  calculatePercentage(score: number, potentialScore: number) {
    return((score/potentialScore).toLocaleString("en", {style: "percent"}))
  }

}
