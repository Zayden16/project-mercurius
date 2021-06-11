import {Component, OnInit} from '@angular/core';
import {MessageService} from 'primeng/api';
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

  constructor(private userService: UserService, private messageService: MessageService, private formBuilder: FormBuilder) {
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
    this.users = await this.userService.getUsers();
  }

  onRowEditInit(user: User) {
    this.clonedUsers[user.User_Id] = {...user};
  }

  onRowEditSave(user: User) {

  }

  onRowEditCancel(user: User, index: number) {
    this.users[index] = this.clonedUsers[user.User_Id];
    delete this.clonedUsers[user.User_Id];
  }

  onRowDelete(user: User) {
    delete this.users[user.User_Id];
  }

  async createUser() {
    this.submitted = true;

    if (this.newUserForm.invalid) {
      return;
    }

    console.log(await this.userService.createUser(this.newUser));
  }

  async updateUser() {
     console.log(await this.userService.updateUser(this.newUser));
  }

  async deleteTaxRate() {
    await this.userService.deleteTaxRate(3);
  }

  showDialog() {
    this.displayDialog = true;
  }

  get newUserFormControls() { return this.newUserForm.controls; }

  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        // return if another validator has already found an error on the matchingControl
        return;
      }

      // set error on matchingControl if validation fails
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    }
  }
}
