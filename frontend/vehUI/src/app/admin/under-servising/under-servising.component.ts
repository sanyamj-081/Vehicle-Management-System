import { Component, OnInit } from '@angular/core';
import { ServiceRecord, Vehicle } from '../../models/model';
import { ApiService } from '../../common/services/api.service';

@Component({
  selector: 'under-servising',
  templateUrl: './under-servising.component.html',
  styleUrl: './under-servising.component.css'
})
export class UnderServisingComponent implements OnInit {
  serviceRecords: ServiceRecord[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadServiceRecords();
  }

  loadServiceRecords(): void {
    this.apiService.getVehiclesUnderServicing().subscribe(
      (data: ServiceRecord[]) => {
        this.serviceRecords = data;
      },
      error => {
        console.error('Error fetching service records', error);
      }
    );
  }
}
