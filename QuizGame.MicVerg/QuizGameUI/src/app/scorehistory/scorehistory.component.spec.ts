import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScorehistoryComponent } from './scorehistory.component';

describe('ScorehistoryComponent', () => {
  let component: ScorehistoryComponent;
  let fixture: ComponentFixture<ScorehistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ScorehistoryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ScorehistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
