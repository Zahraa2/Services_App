import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScorllToTopComponent } from './scorll-to-top.component';

describe('ScorllToTopComponent', () => {
  let component: ScorllToTopComponent;
  let fixture: ComponentFixture<ScorllToTopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScorllToTopComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScorllToTopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
