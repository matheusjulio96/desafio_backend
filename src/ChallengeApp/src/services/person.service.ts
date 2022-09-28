import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Person } from '../interfaces/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get(filter?: any) {
    return this.http.get<any>(this.baseUrl + 'api/person').pipe(map(r => r.persons as Person[]));
  }
  getById(id: number) {
    return this.http.get<any>(this.baseUrl + `api/person/${id}`).pipe(map(r => r.person as Person));
  }

  create(person: Person): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}api/person`, person);
  }
  update(person: Person): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}api/person/${person.id}`, person);
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}api/person/${id}`);
  }
}
