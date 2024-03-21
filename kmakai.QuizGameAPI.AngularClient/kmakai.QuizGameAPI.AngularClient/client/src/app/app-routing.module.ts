import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { QuizComponent } from './quiz/quiz.component';
import { QuizCreatorComponent } from './quiz-creator/quiz-creator.component';

const routes: Routes = [
  { path: '', component: IndexComponent },
  { path: 'quiz/create', component: QuizCreatorComponent },
  { path: 'quiz/:quizId', component: QuizComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
