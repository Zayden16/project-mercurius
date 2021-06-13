import {Component, OnInit} from '@angular/core';
import {ConfirmationService} from 'primeng/api';
import {User} from 'src/model/User';
import {UserService} from '../../services/user.service';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  users: User[] = [];
  clonedUsers: any;
  displayDialog: boolean = false;
  newUser = {} as User;

  newUserForm: FormGroup;
  submitted = false;

  constructor(private userService: UserService, private confirmService: ConfirmationService, private formBuilder: FormBuilder) {
    this.newUserForm = this.formBuilder.group({
      username: [null, Validators.required],
      firstname: [null, Validators.required],
      lastname: [null, Validators.required],
      email: [null, Validators.required, Validators.email],
      password: [null, Validators.required, Validators.minLength(6)],
      confirmPassword: [null, Validators.required]
    }, {validators: this.MustMatch('password', 'confirmPassword')});
  }

  async ngOnInit(): Promise<void> {
    this.userService.getUsers().then(data => this.users = data);
  }

  // Row Editor

  onRowEditInit(user: User) {
    this.clonedUsers[user.Id] = {...user};
  }

  onRowEditSave(user: User) {
    this.userService.updateUser(user);
  }

  onRowEditCancel(user: User, index: number) {
    this.users[index] = this.clonedUsers[user.Id];
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

  async deleteUser(event: Event, user: User) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.userService.deleteUser(user.Id);
        delete this.users[user.Id];
        location.reload();
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

  // Validation
  get newUserFormControls() { return this.newUserForm.controls; }

  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    }
  }
}
