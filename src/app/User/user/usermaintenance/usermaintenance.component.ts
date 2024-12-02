import { LibeyUser } from 'src/app/entities/libeyuser';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { UbigeoService } from './../../../core/service/ubigeo/ubigeo.service';
import { DocumentType } from './../../../entities/documentType';
import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { DocumentTypeService } from 'src/app/core/service/documentType/document-type.service';
import { RegionService } from 'src/app/core/service/region/region.service';
import { Region } from 'src/app/entities/region';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { Province } from 'src/app/entities/province';
import { ProvinceService } from 'src/app/core/service/province/province.service';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
})
export class UsermaintenanceComponent implements OnInit {
  Form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private libeyUserService: LibeyUserService,
    private documentTypeService: DocumentTypeService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.Form = this.fb.group({
      nroDocumento: ['', Validators.required],
      nombre: ['', Validators.required],
      apPaterno: ['', Validators.required],
      apMaterno: ['', Validators.required],
      direccion: ['', Validators.required],
      selectedDocumentType: ['', Validators.required],
      selectedRegion: ['', Validators.required],
      selectedProvince: ['', Validators.required],
      selectedUbigeo: ['', Validators.required],
      telefono: ['', Validators.required],
      correo: ['', Validators.required],
      contraseña: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.editToLibeyUser();
    this.loadDocumentTypes();
    this.loadRegions();
  }
  Submit() {
    this.registerLibeyUser();
    swal.fire('Se registro exitosamente!', 'Se registro!', 'success');
  }

  documentType: DocumentType[] = [];
  selectedDocumentType: any;

  regions: Region[] = [];
  selectedRegion: any;

  provinces: Province[] = [];
  selectedProvince: any;

  ubigeos: Ubigeo[] = [];
  selectedUbigeo: any;

  loadDocumentTypes(): void {
    this.documentTypeService.getAllDocumentType().subscribe((data: any[]) => {
      this.documentType = data;
    });
  }
  loadRegions(): void {
    this.regionService.getAllRegions().subscribe((data: any[]) => {
      this.regions = data;
    });
  }
  loadProvinces(): void {
    const formData = this.Form.value;
    this.provinceService
      .FindProvinces(formData.selectedRegion)
      .subscribe((data: any[]) => {
        this.provinces = data;
      });
  }
  loadUbigeos(): void {
    const formData = this.Form.value;
    this.ubigeoService
      .FindUbigeos(formData.selectedProvince, formData.selectedRegion)
      .subscribe((data: any[]) => {
        this.ubigeos = data;
      });
  }

  registerLibeyUser() {
    const formData = this.Form.value;
    debugger;
    let libeyUser: LibeyUser = {
      documentNumber: formData.nroDocumento,
      documentTypeId: formData.selectedDocumentType,
      ubigeoCode: formData.selectedUbigeo,
      name: formData.nombre,
      fathersLastName: formData.apPaterno,
      mothersLastName: formData.apMaterno,
      address: formData.direccion,
      phone: formData.telefono,
      email: formData.correo,
      password: formData.contraseña,
    };
    this.param = this.route.snapshot.queryParamMap.get('param');

    this.libeyUserService.CreateOrUpdateUser(libeyUser, this.param);
    this.router.navigate(['/card']); 

  param: string | null = null;
  usuarioEdit: LibeyUser | null = null;

  editToLibeyUser() {
    this.param = this.route.snapshot.queryParamMap.get('param');
    this.libeyUserService.Find(this.param!).subscribe((data: any) => {
      if (Array.isArray(data) && data.length > 0) {
        this.usuarioEdit = data[0];
      } else if (data) {
        this.usuarioEdit = data;
      } else {
        console.error('No se encontraron datos para el usuario');
        this.usuarioEdit = null;
      }
      debugger;
      if (this.usuarioEdit) {
        this.Form.patchValue({
          nroDocumento: this.usuarioEdit.documentNumber || '',
          nombre: this.usuarioEdit.name || '',
          apPaterno: this.usuarioEdit.fathersLastName || '',
          apMaterno: this.usuarioEdit.mothersLastName || '',
          direccion: this.usuarioEdit.address || '',
          selectedDocumentType: this.usuarioEdit.documentTypeId || '',
          selectedRegion: this.usuarioEdit.regionCode || '',
          selectedProvince: this.usuarioEdit.provinceCode || '',
          selectedUbigeo: this.usuarioEdit.ubigeoCode || '',
          telefono: this.usuarioEdit.phone || '',
          correo: this.usuarioEdit.email || '',
          contraseña: '',
        });
      }
    });
  }

  Limpiar() {
    this.Form.patchValue({
      nroDocumento: '',
      nombre: '',
      apPaterno: '',
      apMaterno: '',
      direccion: '',
      selectedDocumentType: '',
      selectedRegion: '',
      selectedProvince: '',
      selectedUbigeo: '',
      telefono: '',
      correo: '',
      contraseña: '',
    });
  }
}
