import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }


  checkLogin(token: string) {
    if (localStorage.getItem(token) === null) {
      return false;
    } else {
      return true;
    }
  }
}
