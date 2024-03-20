import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';

@Component({
  selector: 'app-quiz-creator',
  templateUrl: './quiz-creator.component.html',
  styleUrls: ['./quiz-creator.component.css'],
})
export class QuizCreatorComponent {
  quizForm: FormGroup;
  questionForm: FormGroup;
  quiz: any;
  index: number | null = null;
  questions: any[] = [
    {
      id: 1,
      Text: 'What is 2+2?',
      Answer: 4,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 6,
    },
    {
      id: 2,
      Text: "What's mah mfin name?",
      Answer: 6,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 6,
    },
    {
      id: 3,
      Text: 'What is 4+4?',
      Answer: 8,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 8,
    },
    {
      id: 1,
      Text: 'What is 2+2?',
      Answer: 4,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 6,
    },
    {
      id: 2,
      Text: 'What is 3+3?',
      Answer: 6,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 6,
    },
    {
      id: 3,
      Text: 'What is 4+4?',
      Answer: 8,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 8,
    },
    {
      id: 1,
      Text: 'What is 2+2?',
      Answer: 4,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 6,
    },
    {
      id: 2,
      Text: 'What is 3+3?',
      Answer: 6,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 6,
    },
    {
      id: 3,
      Text: 'What is 4+4?',
      Answer: 8,
      Option1: 3,
      Option2: 4,
      Option3: 5,
      Option4: 8,
    },
  ];
  constructor(private fb: FormBuilder) {
    this.quizForm = this.fb.group({
      id: 0,
      name: ['', Validators.required],
      description: ['', Validators.required],
    });

    this.questionForm = this.fb.group({
      id: 0,
      Text: ['', Validators.required],
      Answer: ['', Validators.required],
      Option1: ['', Validators.required],
      Option2: ['', Validators.required],
      Option3: ['', Validators.required],
      Option4: ['', Validators.required],
    });
  }

  onSubmit() {
    console.log(this.quizForm.value);
  }

  addQuestion(form: HTMLElement) {
    if (this.questionForm.invalid) return;
    if (this.index == null) this.questions.push(this.questionForm.value);
    else {
      this.questions[this.index] = this.questionForm.value;
      this.index = null;
      const formBtn = document.querySelector('.qFormBtn')!;
      formBtn.innerHTML = 'Add';
      this.questionForm.reset();
    }
  }

  deleteQuestion(index: number) {
    this.questions.splice(index, 1);
  }

  editQuestion(index: number) {
    const q = this.questions[index];
    this.questionForm.setValue(q);
    const formBtn = document.querySelector('.qFormBtn')!;
    formBtn.innerHTML = 'Save';
    this.index = index;
  }
}
