import { Injectable } from '@angular/core';

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


  constructor() {

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
    if(this._users[user.email]){
      if(this._users[user.email].password === user.password){
        return {
                ... this._users[user.email],  //copy all value from this object
                password:null  //replace password. 
              };
      }    
    }

    throw new Error("Invalid credentials");
  }



  
}
