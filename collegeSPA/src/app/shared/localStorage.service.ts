import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class localStorageservice {

  constructor() { }

  setLocalStoarge(key: string, value: string) {
    localStorage.setItem(key, value);
  }

  getLocalStoarge(key: string) {
    return localStorage.getItem(key);
  }

  removeLocalStoarge(key: string) {
    return localStorage.removeItem(key);
  }
}
