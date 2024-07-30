import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'page-header',
  templateUrl: './page-header.component.html',
  styleUrl: './page-header.component.css'
})
export class PageHeaderComponent {

  loggedIn: boolean = false;
  name: string = '';

  constructor(private apiService: ApiService) {
    apiService.userStatusObservable.subscribe({
      next: (res) => {
        if (res == 'loggedIn') {
          this.loggedIn = true;
          let user = apiService.getUserInfo()!;
          this.name = `${user.firstName} ${user.lastName}`;
        } else {
          this.loggedIn = false;
          this.name = '';
        }
      },
    });
  }
  logout() {
    // Add your logout logic here
    this.apiService.logout();
  }
}
