import { Component } from '@angular/core';
import {FormsModule } from '@angular/forms';
import { JsonifyPipe } from '../../../utils/pipes/jsonify.pipe';
import { SimpleUserService, User } from '../../services/simple-user.service';
import { Router } from '@angular/router';
import { CaSlideShowComponent } from '../../../utils/components/ca-slide-show/ca-slide-show.component';
import { CustomPasswordValidator } from '../../../utils/validators/custom-password.validator';


@Component({
  selector: 'user-login',
  standalone: true,
  imports: [
    JsonifyPipe,
    FormsModule,
    CaSlideShowComponent,
    CustomPasswordValidator,
  ],
  templateUrl: './user-login.component.html',
  styleUrl: './user-login.component.css'
})
export class UserLoginComponent {

  constructor(
    private userService:SimpleUserService,
    private router:Router,
    
  ){}

  user:User = {
    email:'',
    password:''
  };

  ngOnInit(){
  }


 
  
  errorMessage="";

  handleLogin(){
    
   
    this
      .userService
      .login(this.user)
      .subscribe({

        next: result=>{
          this.router.navigate(['/']);
        },

        error: error=>{
          
          if(error.status===401)
            this.errorMessage="Invalid Credentials";
          else
            this.errorMessage=`Error: {error.status}`;
        }
      });
  }

}
