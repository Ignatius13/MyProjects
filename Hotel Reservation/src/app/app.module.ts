import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import { LoginComponent } from './login/login.component';
import { MatIconModule } from '@angular/material/icon';
import { AddComponent } from './login/add/add.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { TableComponent } from './login/table/table.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';
import { HttpClientModule } from '@angular/common/http';
import { MatNativeDateModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from "@angular/material/form-field";
import { DeleteComponent } from './delete/delete.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AddComponent,
    TableComponent,
      DeleteComponent,

  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MatProgressSpinnerModule,
    HttpClientModule,
    MatPaginatorModule,
    MatSortModule,
    MatToolbarModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatTableModule,
    MatSelectModule,
    MatIconModule,
    MatSortModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatFormFieldModule,
    BrowserAnimationsModule,
    MatInputModule
    
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
