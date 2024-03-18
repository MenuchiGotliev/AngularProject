import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {
  logoutbe?:boolean=false
  ngOnInit(): void {
    sessionStorage.removeItem('name');
    sessionStorage.removeItem('password');
    sessionStorage.removeItem('id');
  }
 
}