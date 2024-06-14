import { Component } from '@angular/core';
import {FormsModule } from '@angular/forms';

export interface User{
  name?:string;
  email:string;
  password:string;
}

@Component({
  selector: 'user-login',
  standalone: true,
  imports: [
    
    FormsModule,
  ],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent {
  user:User = {
    email:'',
    password:''
  };

  handleLogin(){
    console.log(this.user)
  }

}
