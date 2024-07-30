import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './common/component/page-not-found/page-not-found.component';
import { LoginComponent } from './auth/login/login.component';
import { ScheduledVehicleComponent } from './serviceAdvisor/scheduled-vehicle/scheduled-vehicle.component';
import { VehicleListComponent } from './admin/vehicle-list/vehicle-list.component';
import { UnderServisingComponent } from './admin/under-servising/under-servising.component';
import { ServisedComponent } from './admin/servised/servised.component';
import { VehicleManagementComponent } from './admin/vehicle-management/vehicle-management.component';
import { SAManagementComponent } from './admin/s-a-management/s-a-management.component';
import { WorkItemManagementComponent } from './admin/work-item-management/work-item-management.component';
import { ServiceRecordsComponent } from './admin/service-records/service-records.component';

const routes: Routes = [
  //{path:'register',component:RegisterComponent},
  {path:'login', component:LoginComponent},
  {path: 'all-vehicles',component:VehicleListComponent},  
  {path:'under-servicing',component:UnderServisingComponent},
  {path:'serviced-vehicles',component: ServisedComponent},
  {path: 'manage-vehicles', component: VehicleManagementComponent},
  {path: 'manage-s-a', component:SAManagementComponent },
  {path: 'manage-work-items', component: WorkItemManagementComponent},
  {path: 'reports', component:ServiceRecordsComponent},

  {path:'service-records',component:ScheduledVehicleComponent},
  {path:'**',component:PageNotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
