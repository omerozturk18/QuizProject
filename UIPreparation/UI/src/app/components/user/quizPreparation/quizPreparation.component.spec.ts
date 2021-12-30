import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizPreparationComponent } from './quizPreparation.component';

describe('QuizPreparationComponent', () => {
  let component: QuizPreparationComponent;
  let fixture: ComponentFixture<QuizPreparationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuizPreparationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizPreparationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
