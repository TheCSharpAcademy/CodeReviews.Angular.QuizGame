import { Component, OnInit, ViewChild } from '@angular/core';
import { DecodeHTMLEntitiesPipe } from '../decode-htmlentities.pipe';
import { GameService } from './game.service';
import { TrivaDbServiceService } from '../triva-db-service.service';
import { MatButtonModule } from '@angular/material/button';
import { NgClass } from '@angular/common';
import { AnswerboxComponent } from './answerbox/answerbox.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { MainmenuService } from '../main-menu/mainmenu.service';

@Component({
  selector: 'app-game',
  standalone: true,
  imports: [
    DecodeHTMLEntitiesPipe,
    MatButtonModule,
    AnswerboxComponent,
    NgClass,
    MatProgressBarModule
  ],
  templateUrl: './game.component.html',
  styleUrl: './game.component.scss',
  host: {
    button: "class='answerButton'",
  },
})

export class GameComponent implements OnInit {

  constructor(
    public gameService: GameService,
    public triviaDbService: TrivaDbServiceService,
    public menuService:MainmenuService
  ) {}

  @ViewChild('correct') correctSound: any;
  @ViewChild('wrong') wrongSound: any;

  get quizQuestions() {
    return this.triviaDbService.questionsInQuiz.asReadonly();
  }

  get isLoaded(){
    return this.triviaDbService.isLoaded();
  }
  get questionIndex(){return this.gameService.questionIndex.asReadonly()}
  get wrongAnswers (){return this.gameService.wrongAnswers.asReadonly()}
  get selectedAnswer(){return this.gameService.selectedAnswer.asReadonly()}
  get isCorrect(){return this.gameService.isCorrect.asReadonly()}
  get isAnswerSelected(){return this.gameService.isAnswerSelected.asReadonly()}
  get isGameOver(){return this.gameService.isGameOver.asReadonly()}
  get wrongAnsweredQuestions(){return this.gameService.wrongAnsweredQuestions}

  async ngOnInit() {
    await this.startNewGame()

  }

  async startNewGame(){
    if (this.quizQuestions().length<1){
      await this.triviaDbService.getQuestionsFromTriviaDbAsync();
    }
    this.gameService.isGameOver.set(false);
  }

  async returnMainMenu(){
    await this.triviaDbService.getQuestionsFromTriviaDbAsync();
    this.gameService.games.set([]);
    this.menuService.returnMainMenu();
  }

  onSelectAnswer(selected: string) {
    if (this.isAnswerSelected()) {
      return; 
    }
    this.gameService.selectedAnswer.set(selected);
    this.gameService.isCorrect.set(selected === this.quizQuestions()[this.questionIndex()].correct_answer);
    this.isCorrect()?this.correctSound.nativeElement.play():this.wrongSound.nativeElement.play();
    this.gameService.isAnswerSelected.set(true);


    if (!this.isCorrect()) {
      this.gameService.wrongAnswers.set(this.gameService.wrongAnswers() + 1);
      this.gameService.wrongAnsweredQuestions.push(
        this.quizQuestions()[this.questionIndex()]
      );
    }
    if (this.gameService.questionIndex() < this.quizQuestions().length - 1) {
    setTimeout(() => {
        this.gameService.questionIndex.set(this.gameService.questionIndex()+1);
        this.resetQuestionState()      
    }, 1600);
  } else {
    setTimeout(()=>{
      this.resetQuestionState();
      this.endGame();
    },1600)
  }
  }

  resetQuestionState(){
    this.gameService.selectedAnswer.set(null);
    this.gameService.isCorrect.set(null);
    this.gameService.isAnswerSelected.set(false);      
  }

  async endGame(){
     this.triviaDbService.isLoaded.set(false)
    await this.gameService.onGameEnd()
    this.gameService.resetGame();
    await this.gameService.getGames();
  }
}
