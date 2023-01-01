import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  @Output() loggedin = new EventEmitter<boolean>();
  constructor() { }

  ngOnInit(): void {
  }


  logOut() {
    this.loggedin.emit(false)
  }
}
