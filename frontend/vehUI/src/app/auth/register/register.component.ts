import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../common/services/api.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  hidePwdContent: boolean = true;
  registerForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private apiService: ApiService,
    private snackBar: MatSnackBar
  ) {
    this.registerForm = fb.group({
      firstName: fb.control('', [Validators.required]),
      lastName: fb.control('', [Validators.required]),
      email: fb.control('', [Validators.required, Validators.email]),
      mobileNumber: fb.control('', [Validators.required]),
      password: fb.control('', [Validators.required]),
      rpassword: fb.control('', [Validators.required]),
    });
  }

  // Function to check if passwords match
  passwordsMatch(): boolean {
    return this.registerForm.get('password')?.value === this.registerForm.get('rpassword')?.value;
  }

  // Register function
  register() {
    if (!this.passwordsMatch()) {
      this.snackBar.open('Passwords do not match', 'OK');
      return;
    }

    const user = {
      firstName: this.registerForm.get('firstName')?.value,
      lastName: this.registerForm.get('lastName')?.value,
      email: this.registerForm.get('email')?.value,
      mobileNumber: this.registerForm.get('mobileNumber')?.value,
      password: this.registerForm.get('password')?.value,
      rpassword: this.registerForm.get('rpassword')?.value,
    };

    this.apiService.register(user).subscribe({
      next: (res: any) => {
        if (res.status === 'success') {
          this.snackBar.open('Registration successful', 'OK');
        } else {
          this.snackBar.open(res.message || 'Registration failed', 'OK');
        }
      },
      error: (err) => {
        this.snackBar.open('An error occurred', 'OK');
      },
    });
  }
}
