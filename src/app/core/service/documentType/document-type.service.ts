import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DocumentTypeService {
  constructor(private http: HttpClient) {}

  getAllDocumentType(): Observable<DocumentType[]> {
    const uri = `${environment.pathLibeyTechnicalTest}DocumentType`;
    return this.http.get<DocumentType[]>(uri);
  }
}
