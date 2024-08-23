import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GradoService {
  private baseApiUrl = 'https://localhost:7068/api/v1/';

  constructor(private http: HttpClient) {}

  getGrados(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseApiUrl}grados`);
  }

  addGrado(grado: any): Observable<any> {
    return this.http.post<any>(`${this.baseApiUrl}grados`, grado);
  }

  updateGrado(id: number, grado: any): Observable<any> {
    return this.http.patch<any>(`${this.baseApiUrl}grados/${id}`, grado);
  }

  deleteGrado(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseApiUrl}grados/${id}`);
  }
}
