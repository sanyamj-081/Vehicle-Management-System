import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PageHeaderComponent } from './common/component/page-header/page-header.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MaterialModule } from './material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PageFooterComponent } from './common/component/page-footer/page-footer.component';
import { PageSideNavComponent } from './common/component/page-side-nav/page-side-nav.component';
import { PageNotFoundComponent } from './common/component/page-not-found/page-not-found.component';
import { LoginComponent } from './auth/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient } from '@angular/common/http';
import { ScheduledVehicleComponent } from './serviceAdvisor/scheduled-vehicle/scheduled-vehicle.component';
import { AddItemsComponent } from './serviceAdvisor/add-items/add-items.component';
import { RouterModule } from '@angular/router';
import { VehicleListComponent } from './admin/vehicle-list/vehicle-list.component';
import { UnderServisingComponent } from './admin/under-servising/under-servising.component';
import { ServisedComponent } from './admin/servised/servised.component';
import { VehicleManagementComponent } from './admin/vehicle-management/vehicle-management.component';
import { SAManagementComponent } from './admin/s-a-management/s-a-management.component';
import { WorkItemManagementComponent } from './admin/work-item-management/work-item-management.component';
import { DialogContentExampleDialog, ServiceRecordsComponent } from './admin/service-records/service-records.component';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    AppComponent,
    PageHeaderComponent,
    PageFooterComponent,
    PageSideNavComponent,
    PageNotFoundComponent,
    LoginComponent,
    ScheduledVehicleComponent,
    AddItemsComponent,
    VehicleListComponent,
    UnderServisingComponent,
    ServisedComponent,
    VehicleManagementComponent,
    SAManagementComponent,
    WorkItemManagementComponent,
    ServiceRecordsComponent,
    DialogContentExampleDialog
    
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([]),
    AppRoutingModule,
    MaterialModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatDialogModule
   
  ],
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(),
  ],
  bootstrap:[AppComponent]
})
export class AppModule { }
