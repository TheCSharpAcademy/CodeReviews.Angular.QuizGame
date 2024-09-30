export interface Question {
    id: number;
    quizQuestion: string;
    answer1: string;
    answer2: string;
    answer3: string;
    correctAnswer: number;
    quizId: number;
    isAnswerGiven?: boolean;
    selectedAnswerIsCorrect?: boolean;
    selectedAnswerId?: number;
}