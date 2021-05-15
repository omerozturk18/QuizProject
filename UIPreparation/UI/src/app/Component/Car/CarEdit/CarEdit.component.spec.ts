/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CarEditComponent } from './CarEdit.component';

describe('CarEditComponent', () => {
  let component: CarEditComponent;
  let fixture: ComponentFixture<CarEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
