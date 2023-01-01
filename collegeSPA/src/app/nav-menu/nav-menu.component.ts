import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { localStorageservice } from '../shared/localStorage.service';
import { TokenService } from '../shared/token.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  @Output() loggedin = new EventEmitter<boolean>();
  constructor(private localStorage: localStorageservice, private tokenService: TokenService) { }

  ngOnInit(): void {
  }

  logOut() {
    this.localStorage.removeLocalStoarge("token");
    this.loggedin.emit(this.tokenService.checkLogin("token"))
  }
}
