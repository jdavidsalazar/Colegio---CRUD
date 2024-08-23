import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AlumnosService {
  private baseApiUrl = 'https://localhost:7068/api/v1/';

  constructor(private http: HttpClient) {}

  getAlumnos(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseApiUrl}alumnos`);
  }

  addAlumno(alumno: any): Observable<any> {
    return this.http.post<any>(`${this.baseApiUrl}alumnos`, alumno);
  }

  updateAlumno(id: number, alumno: any): Observable<any> {
    return this.http.patch<any>(`${this.baseApiUrl}alumnos/${id}`, alumno);
  }

  deleteAlumno(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}alumnos/${id}`);
  }
}
