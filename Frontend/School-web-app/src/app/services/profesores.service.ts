import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProfesoresService {
  private baseApiUrl = 'https://localhost:7068/api/v1/';

  constructor(private http: HttpClient) {}

  getProfesores(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseApiUrl}profesores`);
  }

  addProfesor(profesor: any): Observable<any> {
    return this.http.post<any>(`${this.baseApiUrl}profesores`, profesor);
  }

  updateProfesor(id: number, profesor: any): Observable<any> {
    return this.http.patch<any>(`${this.baseApiUrl}profesores/${id}`, profesor);
  }

  deleteProfesor(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}profesores/${id}`);
  }
}
