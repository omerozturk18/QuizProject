/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BrandEditComponent } from './BrandEdit.component';

describe('BrandEditComponent', () => {
  let component: BrandEditComponent;
  let fixture: ComponentFixture<BrandEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrandEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrandEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
