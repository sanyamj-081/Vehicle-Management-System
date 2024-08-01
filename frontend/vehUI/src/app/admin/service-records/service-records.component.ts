import { Component, OnInit, Inject } from '@angular/core';
import { ApiService } from '../../common/services/api.service';
import { ServiceRecord } from '../../models/model';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-service-records',
  templateUrl: './service-records.component.html',
  styleUrls: ['./service-records.component.css']
})
export class ServiceRecordsComponent implements OnInit {
  serviceRecords: ServiceRecord[] = [];
  invoiceDetails: any = null;

  displayedColumns: string[] = ['id', 'actions'];

  constructor(private apiService: ApiService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadServiceRecords();
  }

  loadServiceRecords(): void {
    this.apiService.getServiceRecords().subscribe(
      (records: ServiceRecord[]) => {
        console.log('Fetched service records:', records);
        this.serviceRecords = records;
      },
      error => {
        console.error('Error fetching service records', error);
      }
    );
  }

  generateInvoice(serviceRecordId: number): void {
    this.apiService.createInvoice(serviceRecordId).subscribe(
      (invoiceDetails: any) => {
        this.invoiceDetails = invoiceDetails;
        this.showInvoice();
      },
      error => {
        console.error('Error generating invoice', error);
      }
    );
  }

  showInvoice(): void {
    const dialogRef = this.dialog.open(DialogContentExampleDialog, {
      width: '600px',
      data: this.invoiceDetails
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Invoice dialog closed');
    });
  }
}


@Component({
  selector: 'dialog-content-example-dialog',
  template: `
    <h1 mat-dialog-title>Invoice</h1>
    <div mat-dialog-content>
      <p><strong>Service Record ID:</strong> {{ data?.serviceRecordId }}</p>
      <p><strong>Service Advisor:</strong> {{ data?.serviceAdvisorName }}</p>
      <table mat-table [dataSource]="data?.serviceItems" class="mat-elevation-z8">
        <ng-container matColumnDef="workItemName">
          <th mat-header-cell *matHeaderCellDef> Work Item </th>
          <td mat-cell *matCellDef="let item"> {{ item.workItem?.name }} </td>
        </ng-container>
        <ng-container matColumnDef="quantity">
          <th mat-header-cell *matHeaderCellDef> Quantity </th>
          <td mat-cell *matCellDef="let item"> {{ item.quantity }} </td>
        </ng-container>
        <ng-container matColumnDef="cost">
          <th mat-header-cell *matHeaderCellDef> Cost </th>
          <td mat-cell *matCellDef="let item"> {{ item.workItem?.cost }} </td>
          console.log("yessss;;;;;;;;"+ 'item.workItem?.cost);
        </ng-container>
        <ng-container matColumnDef="totalCost">
          <th mat-header-cell *matHeaderCellDef> Total Cost </th>
          <td mat-cell *matCellDef="let item"> {{ (item.quantity * (item.workItem?.cost || 0)) }} </td>
        </ng-container>

        <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
        <tr mat-row *matRowDef="let row; columns: displayedColumns;"></tr>
      </table>
      <p><strong>Total Cost:</strong> {{ data?.totalCost }}</p>
    </div>
    <div mat-dialog-actions>
      <button mat-button (click)="onClose()">Close</button>
    </div>
  `,
  styles: [`
    .mat-elevation-z8 {
      box-shadow: 0 2px 10px rgba(0,0,0,0.2);
    }
  `]
})
export class DialogContentExampleDialog {
  // Define columns that should be displayed in the dialog
  displayedColumns: string[] = ['workItemName', 'quantity', 'cost', 'totalCost'];

  constructor(
    public dialogRef: MatDialogRef<DialogContentExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    console.log(data);
  }

  onClose(): void {
    this.dialogRef.close();
  }
}
