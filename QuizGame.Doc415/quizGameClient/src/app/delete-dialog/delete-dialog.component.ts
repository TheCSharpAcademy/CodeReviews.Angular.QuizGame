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
import { GameService } from '../game/game.service';
import { MainmenuService } from '../main-menu/mainmenu.service';

@Component({
  selector: 'app-delete-dialog',
  standalone: true,
  imports: [MatButtonModule,
    MatDialogActions,
    MatDialogClose,
    MatDialogTitle,
    MatDialogContent,],
    changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './delete-dialog.component.html',
  styleUrl: './delete-dialog.component.scss'
})
export class DeleteDialogComponent {
  readonly dialogRef = inject(MatDialogRef<GamesTableComponent>);
  gameId: string = inject(MAT_DIALOG_DATA).gameId;
  pageSize: number= inject(MAT_DIALOG_DATA).pageSize;

  constructor(
    public gameService:GameService,
    public menuService:MainmenuService
  ){}

  async onConfirm() {
    await this.gameService.deleteGame(this.gameId)
    await this.gameService.getGames(1,this.pageSize)
    this.menuService.startStats();

  }
}
