export enum UserType {
    NONE = 0,
    SERVICE_ADVISOR = 1,
    ADMIN = 2
  }
  
  export enum AccountStatus {
    UNAPPROVED = 0,
    APPROVED = 1,
    SUSPENDED = 2
  }

export enum ServiceStatus
{
    DUE,
    UNDER_SERVICE,
    COMPLETED
}
export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  mobileNumber: string;
  createdOn: string;
  userType: UserType;
  accountStatus: AccountStatus; 
}
export interface Vehicle {
    id: number;
    licensePlate: string;
    model: string;
    ownerId: number;
}

export interface WorkItem {
  id: number;
  name: string;
  cost: number;
}

export interface ServiceItem {
  workItem: WorkItem;
  quantity: number;
}

export interface ServiceRecord {
  id: number;
  serviceAdvisor: {
    id: number;
    name: string;
  } | null;
  serviceItems: ServiceItem[];
}

