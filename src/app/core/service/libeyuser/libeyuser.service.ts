import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { LibeyUser } from 'src/app/entities/libeyuser';
@Injectable({
  providedIn: 'root',
})
export class LibeyUserService {
  constructor(private http: HttpClient) {}

  Find(documentNumber: string): Observable<LibeyUser> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    return this.http.get<LibeyUser>(uri);
  }

  GetAll(): Observable<LibeyUser[]> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
    return this.http.get<LibeyUser[]>(uri);
  }

  CreateOrUpdateUser(libeyUser: LibeyUser, documentNumber: string | null) {
    if (documentNumber) {
      const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
      console.log(uri);
      return this.http
        .put<LibeyUser>(uri, libeyUser)
        .subscribe((x) => x.active);
    }
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/`;
    return this.http.post<LibeyUser>(uri, libeyUser).subscribe((x) => x.active);
  }

  DeleteUser(documentNumber: string) {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    return this.http.delete<LibeyUser>(uri);
  }
}
