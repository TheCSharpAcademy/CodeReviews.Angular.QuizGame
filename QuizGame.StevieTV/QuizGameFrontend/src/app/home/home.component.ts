import { Component } from '@angular/core';
import { AddQuestionComponent } from "../addquestion/add-question.component";
import { QuestionsComponent } from "../questions/questions.component";

@Component({
  selector: 'app-home',
  standalone: true,
    imports: [
        AddQuestionComponent,
        QuestionsComponent
    ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
