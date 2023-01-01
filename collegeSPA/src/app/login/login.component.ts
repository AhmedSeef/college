import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from '../services/Auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {}
  @Output() loggedin = new EventEmitter<boolean>();

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
  }

  logIn() {

    this.auth.login(this.model).subscribe(
      Response => { this.loggedin.emit(true) }
    );
  }
}
