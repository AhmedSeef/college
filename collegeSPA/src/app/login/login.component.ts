import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../services/Auth.service';
import { localStorageservice } from '../shared/localStorage.service';
import { TokenService } from '../shared/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {}
  @Output() loggedin = new EventEmitter<boolean>();

  constructor(private auth: AuthService, private localStorage: localStorageservice, private tokenService: TokenService) { }

  ngOnInit(): void {
  }

  logIn() {

    this.auth.login(this.model).subscribe(
      Response => {
        this.localStorage.setLocalStoarge("token", Response.toString());
        this.loggedin.emit(this.tokenService.checkLogin("token"));
      }
    );
  }
}
