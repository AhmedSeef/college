import { Component } from '@angular/core';
import { TokenService } from './shared/token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoggedIn: boolean = this.tokenService.checkLogin("token");
  title = 'collegeSPA';
  constructor(private tokenService: TokenService) {

  }

  changeLoginSataus(status: any) {
    this.isLoggedIn = this.tokenService.checkLogin("token");
  }
}
