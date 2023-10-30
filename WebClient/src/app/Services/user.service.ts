import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Classes/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl: string = 'https://localhost:7125';

  constructor(private http: HttpClient) { }

  createUser(newUser: User) {
    
    return this.http.post<any>(`${this.baseUrl}/User`, newUser);
  }
}
