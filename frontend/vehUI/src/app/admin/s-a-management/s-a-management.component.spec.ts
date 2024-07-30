import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SAManagementComponent } from './s-a-management.component';

describe('SAManagementComponent', () => {
  let component: SAManagementComponent;
  let fixture: ComponentFixture<SAManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SAManagementComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SAManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
