import { DecimalPipe } from '@angular/common';
import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { formatDate } from '@angular/common';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
} from '@angular/material/dialog';
import { AddComponent } from '../add/add.component';
import { ServiceService } from 'src/app/service.service';

import { LoginComponent } from '../login.component';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs/internal/Observable';
import { MatSort, Sort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Router } from '@angular/router';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],


})




export class TableComponent implements OnInit {

  datasource: any = new MatTableDataSource();
  displayedColumns: string[] = [
    'ReservationId',
    'Hotel',
    'Arrival',
    'Departure',
    'Type',
    'Guest',
    'Price',
    'Manage',
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;

  constructor(
    private ds: ServiceService,
    private dialog: MatDialog,
    private formBuilder: FormBuilder,
    private _liveAnnouncer: LiveAnnouncer,
    private route: Router
  ) {
    this.ds.getData().subscribe((x) => {
      this.datasource = x;

      console.log(this.datasource);
    });
  }

  ngOnInit(): void {
    this.ds.getData().subscribe((x: any) => {
      this.datasource = new MatTableDataSource(x);
      this.datasource.paginator = this.paginator;
      (this.datasource.sort = this.matSort), console.log(this.datasource);
    });
  }

  openDialog() {
    this.dialog.open(AddComponent, {
      height: '90%',
      width: '50%',
    });
  }
  backToHome(){
    this.route.navigate([''])
  }

  edit(value: number) {
    console.log(value);
    this.dialog.open(AddComponent, {
      height: '90%',
      width: '90%',
      data: value,
    });
  }
  filterData($event: any) {
    this.datasource.filter = $event.target.value;
  }

  pidelete(data: number) {
    console.log(data);        
    this.ds.deleteData(data);
    window.location.reload();
  }




  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }
}
