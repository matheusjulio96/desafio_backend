import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { City } from '../interfaces/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get(filter?: any) {
    return this.http.get<any>(this.baseUrl + 'api/city').pipe(map(r => r.cities as City[]));
  }
  getById(id: number) {
    return this.http.get<any>(this.baseUrl + `api/city/${id}`).pipe(map(r => r.city as City));
  }

  create(city: City): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}api/city`, city);
  }
  update(city: City): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}api/city/${city.id}`, city);
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}api/city/${id}`);
  }
}
