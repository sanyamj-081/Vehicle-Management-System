import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleServiceDialogComponent } from './schedule-service-dialog.component';

describe('ScheduleServiceDialogComponent', () => {
  let component: ScheduleServiceDialogComponent;
  let fixture: ComponentFixture<ScheduleServiceDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ScheduleServiceDialogComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScheduleServiceDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
