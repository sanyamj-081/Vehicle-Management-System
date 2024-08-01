import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../common/services/api.service';
import { Vehicle } from '../../models/model';
import { MatDialog } from '@angular/material/dialog';
import { ScheduleServiceDialogComponent } from '../schedule-service-dialog/schedule-service-dialog.component';
import { ServiceStatus } from '../../models/model';

@Component({
  selector: 'vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[] = [];
  filteredVehicles: Vehicle[] = [];
  displayedColumns: string[] = ['id', 'model', 'licensePlate', 'ownerId', 'actions'];

  constructor(private apiService: ApiService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadVehicles();
  }

  loadVehicles(): void {
    this.apiService.getVehiclesDueForServicing().subscribe(
      (data: Vehicle[]) => {
        this.vehicles = data;
        this.filteredVehicles = data; // Initialize with all vehicles
      },
      error => {
        console.error('Error fetching vehicles', error);
      }
    );
  }

  getVehicleCount(): number {
    return this.filteredVehicles.length;
  }

  scheduleService(vehicle: Vehicle): void {
    const dialogRef = this.dialog.open(ScheduleServiceDialogComponent, {
      width: '250px',
      data: { vehicle: vehicle }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // result is the service advisor ID
        this.apiService.scheduleService(vehicle.id, result).subscribe(
          (serviceRecord: any) => {
            // Update service status to UNDER_SERVICE
            this.apiService.updateServiceStatus(serviceRecord.id, ServiceStatus.UNDER_SERVICE).subscribe(
              () => {
                // Reload vehicles or update filteredVehicles
                this.loadVehicles();
              },
              error => {
                console.error('Error updating service status', error);
              }
            );
          },
          error => {
            console.error('Error scheduling service', error);
          }
        );
      }
    });
  }
}
