import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { AccountStatus, ServiceItem, ServiceRecord, User, UserType, Vehicle, WorkItem } from '../../models/model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private API_BASE_URL = 'https://localhost:7032/api';

  private userStatus = new Subject<string>();
  private userType: string | null = null;
  
  constructor(private http: HttpClient) {}

  // ===========================================================================================
  //                 LOGIN / LOGOUT OPEARTIONS
  // =========================================================================================== 
  
  // Login method
  login(loginInfo: { email: string; password: string }): Observable<any> {
    const url = `${this.API_BASE_URL}/auth/Login`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(url, loginInfo, { headers });
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('isLoggedIn') === 'true';
  }
  
    // Set login status and store user information
  setLoggedIn(status: boolean, userType: string, userInfo: User): void {
    localStorage.setItem('isLoggedIn', status.toString());
    localStorage.setItem('userType', userType);
    localStorage.setItem('userInfo', JSON.stringify(userInfo));
    this.userStatus.next(status ? 'loggedIn' : 'loggedOff'); 
  }
  
    // Get user type
  getUserType(): string | null {
    return this.userType || localStorage.getItem('userType');
  }
  
    // Get user information
  getUserInfo(): User | null {
    if (!this.isLoggedIn()) return null;
    const userInfo = localStorage.getItem('userInfo');
    return userInfo ? JSON.parse(userInfo) as User : null;
  }
  
  // Log out the user
  logout(): void {
    localStorage.removeItem('isLoggedIn');
    localStorage.removeItem('userType');
    localStorage.removeItem('userInfo');
    this.userStatus.next('loggedOff'); 
  }  

  get userStatusObservable(): Observable<string> {
    return this.userStatus.asObservable();
  }


  // ===========================================================================================
  //                 VEHICLE STATUS OPEARTIONS
  // ===========================================================================================

  getVehiclesDueForServicing(): Observable<Vehicle[]> {
    const url = `${this.API_BASE_URL}/admin/VehiclesDueForServicing`;
    return this.http.get<Vehicle[]>(url);
  }

  // Get vehicles under servicing
  getVehiclesUnderServicing(): Observable<ServiceRecord[]> {
    const url = `${this.API_BASE_URL}/admin/VehiclesUnderServicing`;
    return this.http.get<ServiceRecord[]>(url);
  }

  // Get vehicles serviced
  getVehiclesServiced(): Observable<ServiceRecord[]> {
    const url = `${this.API_BASE_URL}/admin/VehiclesServiced`;
    return this.http.get<ServiceRecord[]>(url);
  }

  // ===========================================================================================
  //                 CRUD - PRIVILAGES FOR PARTICUALR SERVICE ADVISOR
  // ===========================================================================================

  getScheduledServicesForAdvisor(serviceAdvisorId: number): Observable<ServiceRecord[]> {
    const url = `${this.API_BASE_URL}/ServiceAdvisor/ScheduledServices`;
    return this.http.get<ServiceRecord[]>(url, {
      params: { serviceAdvisorId: serviceAdvisorId.toString() }
    });
  }

  getServiceRecordForAdvisor(id: number): Observable<ServiceRecord> {
    const url = `${this.API_BASE_URL}/ServiceAdvisor/ServiceRecord/${id}`; // Adjusted the URL to be under serviceadvisor
    return this.http.get<ServiceRecord>(url);
  }

  addServiceItem(serviceRecordId: number, workItemId: number, quantity: number): Observable<void> {
    const url = `${this.API_BASE_URL}/ServiceAdvisor/AddServiceItem`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { serviceRecordId, workItemId, quantity };
    console.log(body);
    return this.http.post<void>(url, body, { headers });
  }  

  updateVehicleStatus(vehicleId: number, status: string): Observable<void> {
    return this.http.patch<void>(`${this.API_BASE_URL}/Vehicle/UpdateStatus/${vehicleId}`, {
      status
    });
  }   

  getServiceRecords(): Observable<ServiceRecord[]> {
    const url = `${this.API_BASE_URL}/admin/GetServiceRecords`;
    return this.http.get<ServiceRecord[]>(url);
  }  


  // ===============================================
  //                 INVOICE CREATE
  // ===============================================

  createInvoice(serviceRecordId: number): Observable<any> {
    const url = `${this.API_BASE_URL}/admin/CreateInvoice`;
    return this.http.post<any>(url, null, {
      params: { serviceRecordId: serviceRecordId.toString() }
    })
  }



  // ===============================================
  //                 CRUD - VEHICLES
  // ===============================================


  getVehicles(): Observable<Vehicle[]> {
      const url = `${this.API_BASE_URL}/admin/GetVehicles`;
      return this.http.get<Vehicle[]>(url);
  }

  createVehicle(vehicle: Vehicle): Observable<Vehicle> {
      const url = `${this.API_BASE_URL}/admin/CreateVehicles`;
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      return this.http.post<Vehicle>(url, vehicle, { headers });
  }

  updateVehicle(id: number, vehicle: Vehicle): Observable<void> {
      const url = `${this.API_BASE_URL}/admin/Vehicles/${id}`;
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      return this.http.put<void>(url, vehicle, { headers });
  }

  deleteVehicle(id: number): Observable<void> {
      const url = `${this.API_BASE_URL}/admin/Vehicles/${id}`;
      return this.http.delete<void>(url);
  }


  // ===============================================
  //                 CRUD - SERVICE ADVISORS
  // ===============================================


  getServiceAdvisors(): Observable<User[]> {
    const url = `${this.API_BASE_URL}/admin/GetSA`;
    return this.http.get<User[]>(url);
  }

  createServiceAdvisor(advisor: User): Observable<User> {
    const url = `${this.API_BASE_URL}/admin/CreateSA`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    advisor.accountStatus = AccountStatus.UNAPPROVED; // assuming UNAPPROVED = 0
    advisor.userType = UserType.SERVICE_ADVISOR; // as
    console.log(advisor);
    return this.http.post<User>(url, advisor, { headers });
  }

  updateServiceAdvisor(id: number, advisor: User): Observable<void> {
    const url = `${this.API_BASE_URL}/admin/SA/${id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<void>(url, advisor, { headers });
  }

  deleteServiceAdvisor(id: number): Observable<void> {
    const url = `${this.API_BASE_URL}/admin/SA/${id}`;
    return this.http.delete<void>(url);
  }

  // ===============================================
  //                 CRUD - WORK ITEM
  // ===============================================

  getWorkItems(): Observable<WorkItem[]> {
    const url = `${this.API_BASE_URL}/admin/GetWorkItem`;
    return this.http.get<WorkItem[]>(url);
  }

  createWorkItem(workItem: WorkItem): Observable<WorkItem> {
    const url = `${this.API_BASE_URL}/admin/CreateWorkItem`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<WorkItem>(url, workItem, { headers });
  }

  updateWorkItem(id: number, workItem: WorkItem): Observable<void> {
    const url = `${this.API_BASE_URL}/admin/UpdateWorkItem/${id}`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<void>(url, workItem, { headers });
  }

  deleteWorkItem(id: number): Observable<void> {
    const url = `${this.API_BASE_URL}/admin/DeleteWorkItem/${id}`;
    return this.http.delete<void>(url);
  }
}