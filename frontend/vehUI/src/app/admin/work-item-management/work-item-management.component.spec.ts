import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkItemManagementComponent } from './work-item-management.component';

describe('WorkItemManagementComponent', () => {
  let component: WorkItemManagementComponent;
  let fixture: ComponentFixture<WorkItemManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WorkItemManagementComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WorkItemManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
