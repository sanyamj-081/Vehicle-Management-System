import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router'; // Import Router for redirection
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from '../../common/services/api.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  hidePassword: boolean = true;

  constructor(fb: FormBuilder, private apiService: ApiService, private snackBar: MatSnackBar, private router: Router) {
    this.loginForm = fb.group({
      email: fb.control('', [Validators.required]),
      password: fb.control('', [Validators.required]),
    });
  }

  login() {
    let loginInfo = {
      email: this.loginForm.get('email')?.value,
      password: this.loginForm.get('password')?.value,
    };

    this.apiService.login(loginInfo).subscribe({
      next: (res) => {
          if (res.status === 'unapproved') {
              this.snackBar.open('Account is unapproved', 'OK');
          } else if (res.status === 'suspended') {
              this.snackBar.open('Account is suspended', 'OK');
          } else if (res.status === 'success') {
              if (res.userType) {

                  this.apiService.setLoggedIn(true, res.userType, res.userInfo);
                  this.snackBar.open('Login succeeded,', 'Close', { duration: 3000 });
                   // Navigate to home page based on user type
                  if (res.userType === 'ADMIN') {
                    this.router.navigateByUrl('/admin-home');
                  } else if (res.userType === 'SERVICE_ADVISOR') {
                    this.router.navigateByUrl('/service-advisor-home');
                  }
              } else {
                  this.snackBar.open('Login succeeded, but user type is missing', 'Close', { duration: 3000 });
              }
          } else if (res.status === 'not found') {
              this.snackBar.open('Invalid credentials', 'Close', { duration: 3000 });
          } else {
              this.snackBar.open('Unexpected response status', 'Close', { duration: 3000 });
          }
      },
      error: (err) => {
          console.error('Login error:', err);
          this.snackBar.open('Login failed. Please try again.', 'Close', { duration: 3000 });
      }
  });
  
  }
}
