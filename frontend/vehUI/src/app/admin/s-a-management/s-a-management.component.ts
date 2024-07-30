import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../common/services/api.service';
import { User, UserType, AccountStatus } from '../../models/model';

@Component({
  selector: 's-a-management',
  templateUrl: './s-a-management.component.html',
  styleUrls: ['./s-a-management.component.css']
})
export class SAManagementComponent implements OnInit {
  serviceAdvisors: User[] = [];
  newServiceAdvisor: User = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    mobileNumber: '',
    createdOn: new Date().toISOString(),
    userType: UserType.SERVICE_ADVISOR,
    accountStatus: AccountStatus.UNAPPROVED
  };
  selectedServiceAdvisor: User | null = null;

  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email', 'mobileNumber', 'accountStatus', 'actions'];
  accountStatuses: string[] = Object.values(AccountStatus).filter(value => typeof value === 'string') as string[];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.loadServiceAdvisors();
  }

  loadServiceAdvisors(): void {
    this.apiService.getServiceAdvisors().subscribe(
      (data: User[]) => {
        this.serviceAdvisors = data;
      },
      error => {
        console.error('Error fetching service advisors', error);
      }
    );
  }

  addServiceAdvisor(): void {
    this.apiService.createServiceAdvisor(this.newServiceAdvisor).subscribe(
      (advisor: User) => {
        this.serviceAdvisors.push(advisor);
        this.loadServiceAdvisors();
        this.resetForm();
      },
      error => {
        console.error('Error adding service advisor', error);
      }
    );
  }

  editServiceAdvisor(advisor: User): void {
    this.selectedServiceAdvisor = { ...advisor };
  }

  updateServiceAdvisor(): void {
    if (this.selectedServiceAdvisor) {
      this.apiService.updateServiceAdvisor(this.selectedServiceAdvisor.id, this.selectedServiceAdvisor).subscribe(
        () => {
          const index = this.serviceAdvisors.findIndex(advisor => advisor.id === this.selectedServiceAdvisor!.id);
          if (index !== -1) {
            this.serviceAdvisors[index] = this.selectedServiceAdvisor!;
          }
          this.selectedServiceAdvisor = null;
        },
        error => {
          console.error('Error updating service advisor', error);
        }
      );
    }
  }

  deleteServiceAdvisor(id: number): void {
    this.apiService.deleteServiceAdvisor(id).subscribe(
      () => {
        this.serviceAdvisors = this.serviceAdvisors.filter(advisor => advisor.id !== id);
      },
      error => {
        console.error('Error deleting service advisor', error);
      }
    );
  }

  resetForm(): void {
    this.newServiceAdvisor = {
      id: 0,
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      mobileNumber: '',
      createdOn: new Date().toISOString(),
      userType: UserType.SERVICE_ADVISOR,
      accountStatus: AccountStatus.UNAPPROVED
    };
  }
}
