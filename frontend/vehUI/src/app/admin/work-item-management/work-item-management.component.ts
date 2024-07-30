import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../common/services/api.service';
import { WorkItem } from '../../models/model';

@Component({
  selector: 'work-item-management',
  templateUrl: './work-item-management.component.html',
  styleUrls: ['./work-item-management.component.css']
})
export class WorkItemManagementComponent implements OnInit {
  workItems: WorkItem[] = [];
  newWorkItem: WorkItem = {
    id: 0,
    name: '',
    cost: 0
  };
  selectedWorkItem: WorkItem | null = null;

  displayedColumns: string[] = ['id', 'name', 'description', 'cost', 'actions'];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadWorkItems();
  }

  loadWorkItems(): void {
    this.apiService.getWorkItems().subscribe(
      (data: WorkItem[]) => {
        this.workItems = data;
      },
      error => {
        console.error('Error fetching work items', error);
      }
    );
  }

  addWorkItem(): void {
    this.apiService.createWorkItem(this.newWorkItem).subscribe(
      (item: WorkItem) => {
        this.workItems.push(item);
        this.loadWorkItems();
        this.resetForm();
      },
      error => {
        console.error('Error adding work item', error);
      }
    );
  }

  editWorkItem(item: WorkItem): void {
    this.selectedWorkItem = { ...item };
  }

  updateWorkItem(): void {
    if (this.selectedWorkItem) {
      this.apiService.updateWorkItem(this.selectedWorkItem.id, this.selectedWorkItem).subscribe(
        () => {
          const index = this.workItems.findIndex(workItem => workItem.id === this.selectedWorkItem!.id);
          if (index !== -1) {
            this.workItems[index] = this.selectedWorkItem!;
          }
          this.selectedWorkItem = null;
        },
        error => {
          console.error('Error updating work item', error);
        }
      );
    }
  }

  deleteWorkItem(id: number): void {
    this.apiService.deleteWorkItem(id).subscribe(
      () => {
        this.workItems = this.workItems.filter(item => item.id !== id);
      },
      error => {
        console.error('Error deleting work item', error);
      }
    );
  }

  resetForm(): void {
    this.newWorkItem = {
      id: 0,
      name: '',
      cost: 0
    };
  }
}
