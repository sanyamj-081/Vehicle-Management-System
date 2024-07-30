import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServisedComponent } from './servised.component';

describe('ServisedComponent', () => {
  let component: ServisedComponent;
  let fixture: ComponentFixture<ServisedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ServisedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ServisedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
