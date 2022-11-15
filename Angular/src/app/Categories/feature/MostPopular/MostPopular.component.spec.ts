/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MostPopularComponent } from './MostPopular.component';

describe('MostPopularComponent', () => {
  let component: MostPopularComponent;
  let fixture: ComponentFixture<MostPopularComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MostPopularComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MostPopularComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
