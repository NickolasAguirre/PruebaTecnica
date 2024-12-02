import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UbigeoService {
  constructor(private http: HttpClient) {}

  FindUbigeos(provinciaCode: string, regionCode: string): Observable<Ubigeo[]> {
    const uri = `${environment.pathLibeyTechnicalTest}Ubigeo?provinciaCode=${provinciaCode}&regionCode=${regionCode}`;
    console.log(uri);
    return this.http.get<Ubigeo[]>(uri);
  }
}
