import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loader = 'LoginLoader';

  constructor(private authService: AuthService) {
  }

  ngOnInit() {
    this.authService.login();
  }
}
