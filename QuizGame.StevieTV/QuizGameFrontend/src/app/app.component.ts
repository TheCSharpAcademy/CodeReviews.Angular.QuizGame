import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AddQuestionComponent } from "./addquestion/add-question.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { QuestionsComponent } from "./questions/questions.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
  imports: [RouterOutlet, AddQuestionComponent, QuestionsComponent, NavbarComponent]
})
export class AppComponent {
  title = 'QuizGameFrontend';
}
