import { Routes } from '@angular/router';
import { AddQuestionComponent } from "./addquestion/add-question.component";
import { HomeComponent } from "./home/home.component";
import { PlayComponent } from "./play/play.component";
import { PlayquizComponent } from "./playquiz/playquiz.component";
import { QuestionsComponent } from "./questions/questions.component";
import { QuizComponent } from "./quiz/quiz.component";
import { ResultsComponent } from "./results/results.component";

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'addQuestion', component: AddQuestionComponent},
  { path: 'addQuestion/:quizId', component: AddQuestionComponent},
  { path: 'questions', component: QuestionsComponent },
  { path: 'quiz', component: QuizComponent },
  { path: 'play', component: PlayComponent },
  { path: 'playquiz/:quizId', component: PlayquizComponent },
  { path: 'results', component: ResultsComponent }
];
