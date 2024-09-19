import { Question } from "./question.model";

export interface Quiz{
    id:string,
    questions:Question[],
}