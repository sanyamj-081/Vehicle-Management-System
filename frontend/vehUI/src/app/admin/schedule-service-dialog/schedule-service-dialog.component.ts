import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'schedule-service-dialog',
  templateUrl: './schedule-service-dialog.component.html',
  styleUrl: './schedule-service-dialog.component.css'
})
export class ScheduleServiceDialogComponent {

  serviceAdvisorId: string = '';

  constructor(
    public dialogRef: MatDialogRef<ScheduleServiceDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSchedule(): void {
    this.dialogRef.close(this.serviceAdvisorId);
  }
}
