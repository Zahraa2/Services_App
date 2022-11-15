import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvidersHeaderComponent } from './providers-header.component';

describe('ProvidersHeaderComponent', () => {
  let component: ProvidersHeaderComponent;
  let fixture: ComponentFixture<ProvidersHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProvidersHeaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProvidersHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
