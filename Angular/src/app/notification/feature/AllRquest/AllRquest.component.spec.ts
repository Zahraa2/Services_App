/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AllRquestComponent } from './AllRquest.component';

describe('AllRquestComponent', () => {
  let component: AllRquestComponent;
  let fixture: ComponentFixture<AllRquestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllRquestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllRquestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
