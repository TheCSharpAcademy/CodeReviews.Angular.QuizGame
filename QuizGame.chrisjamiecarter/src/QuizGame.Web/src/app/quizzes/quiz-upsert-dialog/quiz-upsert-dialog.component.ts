import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import {
  MatDialogModule,
  MatDialogTitle,
  MatDialogContent,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatStepperModule } from '@angular/material/stepper';
import { Quiz } from '../../shared/quiz.interface';
import { QuizGameService } from '../../shared/quiz-game.service';
import { QuizCreate } from '../../shared/quiz-create.interface';
import { QuestionCreate } from '../../shared/question-create.interface';
import { Question } from '../../shared/question.interface';
import { AnswerCreate } from '../../shared/answer-create.interface';
import { Answer } from '../../shared/answer.interface';
import { validateCorrectAnswers } from '../../validators/correct-answers.validator';

@Component({
  selector: 'app-quiz-upsert-dialog',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatAccordion,
    MatExpansionModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDialogContent,
    MatDialogModule,
    MatDialogTitle,
    MatIconModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatStepperModule,
    ReactiveFormsModule,
  ],
  templateUrl: './quiz-upsert-dialog.component.html',
  styleUrl: './quiz-upsert-dialog.component.css',
})
export class QuizUpsertDialogComponent implements OnInit {
  isInProgress: boolean = false;
  isUpdate: boolean = false;
  quizForm!: FormGroup;
  questionsForm!: FormGroup;

  readonly data: Quiz = inject(MAT_DIALOG_DATA);
  readonly dialogRef = inject(MatDialogRef<QuizUpsertDialogComponent>);
  private formBuilder = inject(FormBuilder);
  private quizGameService = inject(QuizGameService);

  ngOnInit(): void {
    this.isUpdate = !!this.data;

    this.quizForm = this.formBuilder.group({
      id: this.isUpdate ? this.data.id : '',
      name: [this.isUpdate ? this.data.name : '', Validators.required],
      description: this.isUpdate ? this.data.description : '',
      imageUrl: this.isUpdate ? this.data.imageUrl : '',
    });

    this.initialiseInsertForm();

    if (this.isUpdate) {
      this.initialiseUpdateForm(this.data.id);
    }
  }

  get questions(): FormArray {
    return this.questionsForm.get('questions') as FormArray;
  }

  initialiseInsertForm(): void {
    this.questionsForm = this.formBuilder.group({
      questions: this.formBuilder.array([this.createEmptyQuestionFormGroup()]),
    });
  }

  initialiseUpdateForm(quizId: string): void {
    this.quizGameService.getQuizQuestions(quizId).subscribe({
      next: (questions: Question[]) => {
        const questionFormGroups: FormGroup[] = [];

        questions.forEach((question: Question, index: number) => {
          this.quizGameService.getQuestionAnswers(question.id).subscribe({
            next: (answers) => {
              const questionFormGroup = this.createQuestionFormGroup(
                question,
                answers
              );
              questionFormGroups.push(questionFormGroup);

              if (index === questions.length - 1) {
                this.questionsForm = this.formBuilder.group({
                  questions: this.formBuilder.array(questionFormGroups),
                });
              }
            },
          });
        });
      },
    });
  }

  createEmptyAnswerFormGroup(): FormGroup {
    return this.formBuilder.group({
      id: '',
      text: ['', Validators.required],
      isCorrect: false,
    });
  }

  createAnswerFormGroup(answer: Answer): FormGroup {
    return this.formBuilder.group({
      id: answer.id,
      text: [answer.text, Validators.required],
      isCorrect: answer.isCorrect,
    });
  }

  createEmptyQuestionFormGroup(): FormGroup {
    return this.formBuilder.group({
      text: ['', Validators.required],
      answers: this.formBuilder.array(
        [
          this.createEmptyAnswerFormGroup(),
          this.createEmptyAnswerFormGroup(),
          this.createEmptyAnswerFormGroup(),
          this.createEmptyAnswerFormGroup(),
        ],
        validateCorrectAnswers
      ),
    });
  }

  createQuestionFormGroup(question: Question, answers: Answer[]): FormGroup {
    const answerFormGroups = answers.map((answer: Answer) =>
      this.createAnswerFormGroup(answer)
    );
    return this.formBuilder.group({
      id: question.id,
      text: [question.text, Validators.required],
      answers: this.formBuilder.array(answerFormGroups, validateCorrectAnswers),
    });
  }

  onAddQuestion(): void {
    this.questions.push(this.createEmptyQuestionFormGroup());
  }

  onDeleteQuestion(index: number): void {
    this.questions.removeAt(index);
  }

  onGetAnswers(index: number): FormArray {
    return this.questions.at(index).get('answers') as FormArray;
  }

  private insertQuestions(quizId: string): Promise<void> {
    const questions = this.questionsForm.value.questions;

    const questionPromises = questions.map(
      (question: {
        text: string;
        answers: Array<{ text: string; isCorrect: boolean }>;
      }) => {
        return new Promise<void>((resolve, reject) => {
          const questionRequest: QuestionCreate = {
            quizId: quizId,
            text: question.text,
          };

          this.quizGameService.addQuestion(questionRequest).subscribe({
            next: (questionResponse: Question) => {
              const answerPromises = question.answers.map((answer) => {
                return new Promise<void>((resolveAnswer, rejectAnswer) => {
                  const answerRequest: AnswerCreate = {
                    questionId: questionResponse.id,
                    text: answer.text,
                    isCorrect: answer.isCorrect,
                  };

                  this.quizGameService.addAnswer(answerRequest).subscribe({
                    next: () => resolveAnswer(),
                    error: rejectAnswer,
                  });
                });
              });

              Promise.all(answerPromises)
                .then(() => resolve())
                .catch(reject);
            },
            error: reject,
          });
        });
      }
    );

    return Promise.all(questionPromises).then(() => undefined);
  }

  private insertQuiz(): Promise<void> {
    return new Promise((resolve, reject) => {
      const quizRequest: QuizCreate = {
        name: this.quizForm.value.name,
        description: this.quizForm.value.description,
        imageUrl: this.quizForm.value.imageUrl,
      };

      this.quizGameService.addQuiz(quizRequest).subscribe({
        next: (quizResponse: Quiz) => {
          this.insertQuestions(quizResponse.id).then(resolve).catch(reject);
        },
        error: reject,
      });
    });
  }

  private updateQuiz(): Promise<void> {
    return new Promise((resolve, reject) => {
      const quiz: Quiz = {
        id: this.quizForm.value.id,
        name: this.quizForm.value.name,
        description: this.quizForm.value.description,
        imageUrl: this.quizForm.value.imageUrl,
      };

      this.quizGameService.deleteQuizQuestions(quiz.id).subscribe({
        next: () => {
          this.quizGameService.editQuiz(quiz).subscribe({
            next: (quizResponse: Quiz) => {
              this.insertQuestions(quizResponse.id).then(resolve).catch(reject);
            },
            error: reject,
          });
        },
        error: reject,
      });
    });
  }

  onPublish() {
    if (this.quizForm.invalid || this.questionsForm.invalid) {
      return;
    }

    this.isInProgress = true;

    (async () => {
      if (this.isUpdate) {
        try {
          await this.updateQuiz();
          this.dialogRef.close('Quiz updated successfully!');
        } catch (error) {
          this.dialogRef.close('Unable to update Quiz!');
        } finally {
          this.isInProgress = false;
        }
      } else {
        try {
          await this.insertQuiz();
          this.dialogRef.close('Quiz created successfully!');
        } catch (error) {
          this.dialogRef.close('Unable to create Quiz!');
        } finally {
          this.isInProgress = false;
        }
      }
    })();
  }
}
