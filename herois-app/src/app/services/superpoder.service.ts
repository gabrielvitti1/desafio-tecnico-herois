import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Superpoder } from '../models/superpoder';
import { environment } from 'src/environment';

@Injectable({
  providedIn: 'root'
})
export class SuperpoderService {
  constructor(private http: HttpClient) {}

  // GET /api/superpoderes
  getSuperpoderes(): Observable<Superpoder[]> {
    return this.http.get<Superpoder[]>(environment.api_superpoder);
  }
}
