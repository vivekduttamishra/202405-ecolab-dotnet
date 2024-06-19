import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';

export interface User {
  name?: string;
  email: string;
  password: string;
  roles?: string;
}



@Injectable({
  providedIn: 'root'
})
export class SimpleUserService {

  private _users: any = {};

  private _currentUser?: User;
  constructor(
    private http:HttpClient
  ) 
  {

    this._users['admin@books.org'] = {
      name: 'Admin',
      email: 'admin@books.org',
      password: 'pass@123',
      roles: 'Admin'
    }
    this._users['user@books.org'] = {
      name: 'User',
      email: 'user@books.org',
      password: 'pass@123',
      roles: 'User'
    }


  }


  register(user: User) {

    if (!this._users[user.email]) {

      user.roles = 'User';
      this._users[user.email] = user;
      console.log('user registration:', user);

    } else {
      throw new Error("Duplicate User");
    }

  }

  login(user:User){
    
    return this
            .http
            .post('http://localhost:5000/api/auth', user)
            .pipe(
              tap((data:any)=>{
                if(data.token){
                  localStorage.setItem('token',data.token);
                  this._currentUser=data.user;
                  console.log('login success',this._currentUser);
                }
              })
            )

  }



  
}
