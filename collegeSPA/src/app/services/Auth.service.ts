import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'https://localhost:44340/api/User';
  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + "/login", model);
  }
}
