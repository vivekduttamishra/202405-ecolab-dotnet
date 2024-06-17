import { Component } from '@angular/core';
import {FormsModule } from '@angular/forms';
import { JsonifyPipe } from '../../../utils/pipes/jsonify.pipe';

export interface User{
  name?:string;
  email:string;
  password:string;
}

@Component({
  selector: 'user-login',
  standalone: true,
  imports: [
    JsonifyPipe,
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
  loginImage:string ="";

  ngOnInit(){
    this.loginImage=this.loginImages[Math.floor(Math.random()*this.loginImages.length)];
  }


  loginImages=[
    "https://www.eui.eu/Content-Types-Assets/Web-Unit/Student-in-law-library-section.x7622d211.jpg?w=1920&h=1080",
    "https://media.wired.com/photos/5a67e0165269b52524f2d857/191:100/w_2580,c_limit/beautiful-libraries.jpg",
    "https://www.parliament.uk/contentassets/aa8b9933d3cb4364b827e7a60ea898e0/hl_library_roger-harris2022.jpg?width=1000&quality=85",
    "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/Long_Room_Interior%2C_Trinity_College_Dublin%2C_Ireland_-_Diliff.jpg/1200px-Long_Room_Interior%2C_Trinity_College_Dublin%2C_Ireland_-_Diliff.jpg",
    "https://static01.nyt.com/images/2015/10/24/opinion/24manguel/24manguel-superJumbo.jpg",

  ];
  
  handleLogin(){
    console.log(this.user)
  }

}
