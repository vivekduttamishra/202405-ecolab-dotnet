import { Component } from '@angular/core';
import { CaSlideShowComponent } from '../../../utils/components/ca-slide-show/ca-slide-show.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SimpleUserService } from '../../services/simple-user.service';
import { Router } from '@angular/router';
import { strong_password } from '../../../utils/validators/strong-password.validator';
import { custom_password } from '../../../utils/validators/custom-password.validator';

@Component({
  selector: 'user-registration',
  standalone: true,
  imports: [
    CaSlideShowComponent,
    ReactiveFormsModule,
    
  ],
  templateUrl: './user-registration.component.html',
  styleUrl: './user-registration.component.css'
})
export class UserRegistrationComponent {

  registrationForm: FormGroup;

  constructor(
    private userService: SimpleUserService,
    private router: Router,
  ) {
    this.registrationForm = new FormGroup({
      name: new FormControl("",
        [Validators.required]),

      email: new FormControl("",
        [Validators.required, Validators.email]),

      role: new FormControl("",[

      ]),

      password: new FormControl("",
        [
         Validators.required, 
        //  Validators.minLength(6), 
        //  Validators.maxLength(15),
        //  strong_password

          custom_password(5,15,3)
        ],
      ),

      profilePicture: new FormControl("blank.jpg"),
    });
  }

  errors: string[] = [];

  validate() {

    if (this.registrationForm.valid)
      return [];

    var result: string[] = [];
    for (var key in this.registrationForm.controls) {
      console.log(key);
      var control = this.registrationForm.controls[key];
      if (control.invalid) {
        for (var error_key in control.errors) {
          result.push(`${key}: invalid ${error_key}`);
        }
      }
    }

    return result;

  }

  handleRegisteration() {
    this.errors = this.validate();
    if(this.registrationForm.valid) {
      this.userService.register(this.registrationForm.value);
      this.router.navigate(['/user/login']);
    }
  }

}
