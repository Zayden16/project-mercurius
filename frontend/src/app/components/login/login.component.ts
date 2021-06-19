import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {first} from 'rxjs/operators';
import {AuthenticationService} from 'src/app/services/authentication.service';
import {Message, MessageService} from 'primeng/api'
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [MessageService]
})
export class LoginComponent implements OnInit {
  userForm: FormGroup;
  username: string = "";
  password: string = "";
  error: string = "";

  constructor(private router: Router, private authService: AuthenticationService, private route: ActivatedRoute,
              private messageService: MessageService, private formBuilder: FormBuilder) {
    if (this.authService.currentUserValue) {
      this.router.navigateByUrl('/login');
    }

    this.userForm = this.formBuilder.group({
      username: [null, Validators.required],
      password: [null, [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.username, this.password)
      .pipe(first()).subscribe({
      next: () => {
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || 'dashboard';
        this.router.navigate([returnUrl]);
      },
      error: error => {
        this.error = error;

        this.messageService.add({
          severity: 'error',
          summary: 'Login failed',
          detail: this.error
        });
      }
    })
  }
}
