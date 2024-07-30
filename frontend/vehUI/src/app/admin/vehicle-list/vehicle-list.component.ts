import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../common/services/api.service';
import { Vehicle } from '../../models/model';

@Component({
  selector: 'vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[] = [];
  filteredVehicles: Vehicle[] = [];
  displayedColumns: string[] = ['id', 'model', 'licensePlate','model', 'ownerId', 'actions'];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadVehicles();
  }

  loadVehicles(): void {
    this.apiService.getVehicles().subscribe(
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
    // Implement the logic to schedule a service for the selected vehicle
    // You might need to show a dialog or navigate to a different page
    console.log('Schedule service for:', vehicle);
  }
}
