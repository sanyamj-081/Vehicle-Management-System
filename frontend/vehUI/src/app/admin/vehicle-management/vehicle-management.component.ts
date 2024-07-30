import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../../models/model';
import { ApiService } from '../../common/services/api.service';

@Component({
  selector: 'vehicle-management',
  templateUrl: './vehicle-management.component.html',
  styleUrl: './vehicle-management.component.css'
})
export class VehicleManagementComponent implements OnInit {
  vehicles: Vehicle[] = [];
  selectedVehicle: Vehicle | null = null;
  newVehicle: Vehicle = { id: 0, licensePlate: '', model: '', ownerId: 0 };

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadVehicles();
  }

  loadVehicles(): void {
    this.apiService.getVehicles().subscribe(
      (vehicles: Vehicle[]) => {
        this.vehicles = vehicles;
      },
      error => {
        console.error('Error fetching vehicles', error);
      }
    );
  }

  addVehicle(): void {
    this.apiService.createVehicle(this.newVehicle).subscribe(
      (vehicle: Vehicle) => {
        this.vehicles.push(vehicle);
        this.loadVehicles(); 
        this.newVehicle = { id: 0, licensePlate: '', model: '', ownerId: 0 }; // Reset form
      },
      error => {
        console.error('Error adding vehicle', error);
      }
    );
  }

  editVehicle(vehicle: Vehicle): void {
    this.selectedVehicle = { ...vehicle };
  }

  updateVehicle(): void {
    if (this.selectedVehicle) {
      this.apiService.updateVehicle(this.selectedVehicle.id, this.selectedVehicle).subscribe(
        () => {
          this.loadVehicles(); // Refresh the list
          this.selectedVehicle = null;
        },
        error => {
          console.error('Error updating vehicle', error);
        }
      );
    }
  }

  deleteVehicle(vehicleId: number): void {
    this.apiService.deleteVehicle(vehicleId).subscribe(
      () => {
        this.vehicles = this.vehicles.filter(v => v.id !== vehicleId);
      },
      error => {
        console.error('Error deleting vehicle', error);
      }
    );
  }
}

