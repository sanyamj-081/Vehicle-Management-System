import { Component } from '@angular/core';
import { ApiService } from './common/services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  // ngOnInit(): void {
  //   let status = this.apiService.isLoggedIn() ? 'loggedIn' : 'loggedOff';
  //   this.apiService.userStatus.next(status);
  // }
  // constructor(private apiService:ApiService){}

  title = 'vehUI';
}
