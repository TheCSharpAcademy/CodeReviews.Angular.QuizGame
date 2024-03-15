import { Routes } from '@angular/router';
import { AddQuestionComponent } from "./addquestion/add-question.component";
import { HomeComponent } from "./home/home.component";
import { QuestionsComponent } from "./questions/questions.component";

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'addQuestion', component: AddQuestionComponent},
  { path: 'questions', component: QuestionsComponent }
];
