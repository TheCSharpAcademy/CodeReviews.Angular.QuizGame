import { type Question } from "../question.model";

export interface Game {
    date: string,
    wrongAnsweredQuestions:Question[],
    questions:Question[],
    score:number,
    quizId:string,
    gameId:string
}