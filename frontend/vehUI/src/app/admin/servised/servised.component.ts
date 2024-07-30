import { Component, OnInit } from '@angular/core';
import { ServiceRecord } from '../../models/model';
import { ApiService } from '../../common/services/api.service';

@Component({
  selector: 'servised',
  templateUrl: './servised.component.html',
  styleUrl: './servised.component.css'
})
export class ServisedComponent implements OnInit {
  serviceRecords: ServiceRecord[] = []; // Initialize as an empty array

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadServiceRecords();
  }

  loadServiceRecords(): void {
    this.apiService.getVehiclesServiced().subscribe(
        (records: ServiceRecord[]) => {
          this.serviceRecords = records;
        },
        error => {
          console.error('Error fetching serviced records', error);
        }
      );
  }
}