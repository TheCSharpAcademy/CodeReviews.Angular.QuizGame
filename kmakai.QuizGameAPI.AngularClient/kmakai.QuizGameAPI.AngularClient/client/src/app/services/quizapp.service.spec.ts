import { TestBed } from '@angular/core/testing';

import { QuizappService } from './quizapp.service';

describe('QuizappService', () => {
  let service: QuizappService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuizappService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
