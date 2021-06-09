import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AppSettings } from 'src/appsettings';
import { User } from 'src/model/User';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<any>;
  public currentUser: Observable<User>;

  constructor(private httpClient: HttpClient) {
    var newusr: string = localStorage.getItem('currentUser') || '{}';
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(newusr));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User{

    return this.currentUserSubject.value;
  }

  login(Username: string, Password: string){
    return this.httpClient.post<any>(AppSettings.BASE_URL + 'Authentication', {Username, Password})
          .pipe(map(user => {
            var newUser: User = user;
            localStorage.setItem('currentUser', JSON.stringify(newUser));
            return user;
          }));
   }

  logout(){
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }
}
