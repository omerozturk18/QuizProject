/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CarColorEditComponent } from './CarColorEdit.component';

describe('CarColorEditComponent', () => {
  let component: CarColorEditComponent;
  let fixture: ComponentFixture<CarColorEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarColorEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarColorEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
