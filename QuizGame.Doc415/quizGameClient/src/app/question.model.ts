export interface Question     {
    id:string,
    type: string,
    difficulty: string,
    category: string,
    question: string,
    correct_answer: string,
    incorrect_answers: string[]
    all_answers:string[],
    quizId:string
}  