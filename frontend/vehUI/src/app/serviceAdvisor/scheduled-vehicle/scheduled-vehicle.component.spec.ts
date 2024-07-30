import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduledVehicleComponent } from './scheduled-vehicle.component';

describe('ScheduledVehicleComponent', () => {
  let component: ScheduledVehicleComponent;
  let fixture: ComponentFixture<ScheduledVehicleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ScheduledVehicleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScheduledVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
