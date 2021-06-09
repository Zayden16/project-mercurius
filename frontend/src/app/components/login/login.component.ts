import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { User } from 'src/model/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  username: string = "";
  password: string = "";
  error: string = "";
  constructor(private router: Router, private authService: AuthenticationService, private route: ActivatedRoute) {   }

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.username, this.password)
      .pipe(first()).subscribe({
        next: () => {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
          this.router.navigate([returnUrl]);        },
        error: error => {
          this.error = error;
        }
      })
  }

}
