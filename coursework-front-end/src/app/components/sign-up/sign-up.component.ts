import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder } from '@angular/forms';

import { ConfirmPassValdiator } from 'src/app/validators/confirm-password-validator';

import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  email = 'Email';
  password = 'Password';
  confirmPassword = 'ConfirmPassword';
  firstName = 'FirstName';
  lastName = 'LastName';
  country = 'Country';

  errorOccurd = false;

  signUpForm = this.fb.group({
    FirstName: ['', [
      Validators.required,
      Validators.pattern('[a-zA-ZА-Яа-яёЁ]{2,11}')
    ]],
    LastName: ['', [Validators.required,
      Validators.pattern('[a-zA-ZА-Яа-яёЁ]{2,11}')
    ]],
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]],
    ConfirmPassword: ['', [Validators.required, Validators.minLength(6)]],
    Country: ['', [Validators.required]]
  }, {
    validators: ConfirmPassValdiator
  });

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
  }

  onSubmit(): void {
    console.log(this.signUpForm.controls[this.confirmPassword]);
    console.log(this.signUpForm.controls[this.confirmPassword].errors.match);
    if (this.signUpForm.valid) {
      this.authService.signUp(this.signUpForm.value).subscribe(x => {
        this.router.navigate(['/account/signin']);
      }, error => {
        this.errorOccurd = true;
      });
    }
  }

}
