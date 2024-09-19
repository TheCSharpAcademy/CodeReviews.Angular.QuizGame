import { Component, inject, OnInit, signal } from '@angular/core';
import { GameService } from '../game/game.service';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { Question } from '../question.model';
import { GameDetailsDialogComponent } from '../game-details-dialog/game-details-dialog.component';
import { TrivaDbServiceService } from '../triva-db-service.service';
import { MainmenuService } from '../main-menu/mainmenu.service';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-games-table',
  standalone: true,
  imports: [MatTableModule, MatIconModule, MatButtonModule, MatPaginator],
  templateUrl: './games-table.component.html',
  styleUrl: './games-table.component.scss',
})
export class GamesTableComponent implements OnInit {
  private _snackBar = inject(MatSnackBar);
  constructor(
    public gameService: GameService,
    public trivaDbService:TrivaDbServiceService,
    public menuService:MainmenuService) {}
  readonly dialog = inject(MatDialog);
  displayedColumns: string[] = ['Date', 'Score', 'Actions'];
  async ngOnInit() {
    await this.gameService.getGames();
  }

  get games() {
    return this.gameService.games.asReadonly();
  }

  get totalRecordsCount() {
    return this.gameService.totalRecords();
  }

  pageSize=signal<number>(3);


  onPageChange(event: PageEvent) {
    this.pageSize.set(event.pageSize);
    this.gameService.getGames(event.pageIndex+1,this.pageSize())   
  }

  replayQuiz(quiz:Question[]){
    this.trivaDbService.isLoaded.set(true);
    this.trivaDbService.questionsInQuiz.set(quiz)
    this.trivaDbService.shuffleAnswers();
    this.gameService.resetGame();
    this.gameService.isGameOver.set(false);
    this._snackBar.open(`Replaying recorded game`, 'Dismiss', {
      duration: 2000,
    });
    this.menuService.startGame()
      }

   returnMainMenu(){
    this.menuService.returnMainMenu();
  }
  openDeleteDialog(
    enterAnimationDuration: string,
    exitAnimationDuration: string,
    selectedGameId: string
  ): void {
    console.log(selectedGameId)
    this.dialog.open(DeleteDialogComponent, {
      data: { gameId:selectedGameId,pageSize:this.pageSize() },
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
    this.gameService.getGames();
  }

  openDetailsDialog(enterAnimationDuration: string,
    exitAnimationDuration: string,
    inputQuestions: Question[],
    inputWrongAnsweredQuestions:Question[]):void {
      console.log(inputQuestions, inputWrongAnsweredQuestions)
      this.dialog.open(GameDetailsDialogComponent, {
        data: { questions: inputQuestions,wrongAnsweredQuestions:inputWrongAnsweredQuestions},
        width: '1250px',
        maxWidth:'100%',
        enterAnimationDuration,
        exitAnimationDuration,
      });
    }
}
