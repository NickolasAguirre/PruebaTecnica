import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsercardsComponent } from './usercards/usercards.component';
import { UsermaintenanceComponent } from './usermaintenance/usermaintenance.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatTableModule } from '@angular/material/table';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
@NgModule({
  declarations: [UsercardsComponent, UsermaintenanceComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    MatTableModule,
    BrowserModule,
    RouterModule,
  ],
  exports: [UsercardsComponent, UsermaintenanceComponent],
})
export class UserModule {}
