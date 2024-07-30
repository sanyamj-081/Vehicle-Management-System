import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnderServisingComponent } from './under-servising.component';

describe('UnderServisingComponent', () => {
  let component: UnderServisingComponent;
  let fixture: ComponentFixture<UnderServisingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UnderServisingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnderServisingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
