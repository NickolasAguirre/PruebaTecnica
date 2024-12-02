import { LibeyUser } from 'src/app/entities/libeyuser';

import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from './core/service/libeyuser/libeyuser.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  constructor(private _libeyUserService: LibeyUserService) {}
  title = 'LibeyTechnicalTest';
  listadoUser: LibeyUser[] = [];
  displayedColumns: string[] = [
    'documentTypeId',
    'documentNumber',
    'name',
    'fathersLastName',
    'address',
    'phone',
    'email',
    'acciones',
  ];

  documentNumber = '';
  documento = 'DocumentNumber';

  dataSource!: MatTableDataSource<any>;

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll() {
    this._libeyUserService.GetAll().subscribe((data: any[]) => {
      this.listadoUser = data;
      this.dataSource = new MatTableDataSource(this.listadoUser);
    });
  }

  async DeleteAndGet(DocumentNumber: string) {
    this.EliminarUsuario(DocumentNumber);
  }

  listarUsuarios() {
    this._libeyUserService.Find(this.documentNumber).subscribe((data: any) => {
      this.listadoUser = data;
      this.listadoUser = Array.isArray(data) ? data : [data];
      this.dataSource = new MatTableDataSource(this.listadoUser);
      console.log(this.listadoUser);
    });
  }

  EliminarUsuario(DocumentNumber: string) {
    this._libeyUserService.DeleteUser(DocumentNumber).subscribe((x) => {
      x.active;
      this.GetAll();
    });
  }
}
