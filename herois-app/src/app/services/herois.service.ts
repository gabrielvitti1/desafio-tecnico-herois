import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Heroi } from '../models/heroi';
import { environment } from 'src/environment';

@Injectable({
  providedIn: 'root'
})
export class HeroisService {
  constructor(private http: HttpClient) {}

  // GET /api/heroes
  getHerois(): Observable<Heroi[]> {
    return this.http.get<Heroi[]>(environment.api_heroi);
  }

  // GET /api/heroes/{idHeroi}
  getHeroiById(id: number): Observable<Heroi> {
    return this.http.get<Heroi>(`${environment.api_heroi}/${id}`);
  }

  // POST /api/heroes
  createHero(request: any): Observable<void> {
    return this.http.post<void>(environment.api_heroi, request);
  }

  // PATCH /api/heroes/{idHeroi}
  patchHero(id: number, request: any): Observable<any> {
    return this.http.patch<any>(`${environment.api_heroi}/${id}`, request);
  }

  // DELETE /api/heroes/{idHeroi}
  deleteHero(id: number): Observable<string> {
    return this.http.delete<string>(`${environment.api_heroi}/${id}`);
  }
}
