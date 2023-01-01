import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  @Output() loggedin = new EventEmitter<boolean>();
  constructor() { }

  ngOnInit(): void {
  }

  logOut() {
    this.loggedin.emit(false)
  }
}
