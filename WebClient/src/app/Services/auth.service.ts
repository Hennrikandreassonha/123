import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  private path = ""

  googleLogin(credentials: string): Observable<any>{
    const header = new HttpHeaders().set('Content-type', 'application/json');
    
    return this.httpClient.post(this.path + 'googleLogin', JSON.stringify(credentials), { headers: header})
  }

  public signOutExternal = () =>{
    localStorage.removeItem('token');
    console.log("loggedout.")
  }
}
