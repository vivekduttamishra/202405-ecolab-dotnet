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
    //console.log('trying to loggin',this.user);
    
    
    try{
      this.errorMessage = "";
      var result = this.userService.login(this.user);
      console.log('success',result);
      this.router.navigate(['/']);
    }
    catch(e:any){
      //console.log('error',e.message);
      
      this.errorMessage=e.message;
    }
  }

}
