import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControlOptions } from '@angular/forms';
import { ConfirmationService } from 'primeng/api';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/model/User';

@Component({
  selector: 'app-article-position',
  templateUrl: './article-position.component.html',
  styleUrls: ['./article-position.component.scss']
})
export class ArticlePositionComponent implements OnInit {
  positions: User[] = [];
  clonedUsers: any;
  newUser = {} as User;
  newUserForm: FormGroup;

  displayDialog: boolean = false;
  submitted = false;

  constructor(private userService: UserService, private confirmService: ConfirmationService, private formBuilder: FormBuilder) {
    this.newUserForm = this.formBuilder.group({
      username: [null, Validators.required],
      firstname: [null, Validators.required],
      lastname: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(6)]],
      confirmPassword: [null, Validators.required]
    }, {validators: this.MustMatch('password', 'confirmPassword')} as AbstractControlOptions);
   }

  ngOnInit(): void {
    this.userService.getUsers().then(data => this.positions = data);
  }
  
   // Row Editor
   onRowEditInit(user: User) {
    this.clonedUsers[user.Id] = {...user};
  }

  onRowEditCancel(user: User, index: number) {
    this.positions[index] = this.clonedUsers[user.Id];
    delete this.clonedUsers[user.Id];
  }

  // CRUD
  async createUser() {
    this.submitted = true;

    if (this.newUserForm.invalid) {
      return;
    }

    await this.userService.createUser(this.newUser);
    this.hideDialog()
  }

  async updateUser(user: User) {
    await this.userService.updateUser(user);
  }

  async deleteUser(event: Event, user: User) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        await this.userService.deleteUser(user.Id);
        delete this.positions[user.Id];
      },
      reject: () => {
      }
    })

  }

  // Input Dialog
  showDialog() {
    this.displayDialog = true;
  }

  hideDialog() {
    this.displayDialog = false;
  }

  // Form
  get newUserFormControls() {
    return this.newUserForm.controls;
  }

  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({mustMatch: true});
      } else {
        matchingControl.setErrors(null);
      }
    }
  }
}
