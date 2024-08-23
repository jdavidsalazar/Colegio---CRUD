import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AlumnoGradoService {
  private baseApiUrl = 'https://localhost:7068/api/v1/';

  constructor(private http: HttpClient) {}

  getAlumnoGrados(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseApiUrl}alumnogrados`);
  }

  addAlumnoGrado(alumnoGrado: any): Observable<any> {
    return this.http.post<any>(`${this.baseApiUrl}alumnogrados`, alumnoGrado);
  }

  updateAlumnoGrado(id: number, alumnoGrado: any): Observable<any> {
    return this.http.patch<any>(
      `${this.baseApiUrl}alumnogrados/${id}`,
      alumnoGrado
    );
  }

  deleteAlumnoGrado(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}alumnogrados/${id}`);
  }
}
