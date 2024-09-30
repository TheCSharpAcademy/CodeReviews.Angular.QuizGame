import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddquizdialogComponent } from './addquizdialog.component';

describe('AddquizdialogComponent', () => {
  let component: AddquizdialogComponent;
  let fixture: ComponentFixture<AddquizdialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddquizdialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddquizdialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
