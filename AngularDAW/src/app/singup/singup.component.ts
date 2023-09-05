import { Component } from '@angular/core';

@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./singup.component.scss']
})
export class SignupComponent {

  email: string = '';
  password: string = '';

  onSubmit() {
    console.log('Email:', this.email, 'Password:', this.password);
  }

}

