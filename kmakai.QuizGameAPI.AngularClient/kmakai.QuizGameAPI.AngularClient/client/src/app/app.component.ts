import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { QuizappService } from './services/quizapp.service';
import { MatPaginator } from '@angular/material/paginator';
import { merge, of } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {}
