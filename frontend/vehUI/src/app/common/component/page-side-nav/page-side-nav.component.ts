import { Component, OnInit, OnDestroy } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

export interface NavigationItem {
  value: string;
  link: string;
}

@Component({
  selector: 'page-side-nav',
  templateUrl: './page-side-nav.component.html',
  styleUrls: ['./page-side-nav.component.css']
})
export class PageSideNavComponent implements OnInit, OnDestroy {
  panelName: string = '';
  navItems: NavigationItem[] = [];
  private userStatusSubscription: any;

  constructor(private apiService: ApiService, private router: Router) {}

  ngOnInit(): void {
    // Subscribe to user status changes
    this.userStatusSubscription = this.apiService.userStatusObservable.subscribe(status => {
      if (status === 'loggedIn') {
        this.checkUserStatus();
      } else {
        this.redirectToLogin();
      }
    });

    // Initial check
    if (this.apiService.isLoggedIn()) {
      this.checkUserStatus();
    } else {
      this.redirectToLogin();
    }
  }

  checkUserStatus(): void {
    const userType = this.apiService.getUserType();
    if (userType === 'ADMIN') {
      this.panelName = 'Admin Panel';
      this.navItems = [
        { value: 'Due for Servicing', link: '/all-vehicles' },
        { value: 'Under Servicing', link: '/under-servicing' },
        { value: 'Serviced Vehicles', link: '/serviced-vehicles' },
        { value: 'Manage Vehicles', link: '/manage-vehicles' },
        { value: 'Manage Customers', link: '/manage-customers' },
        { value: 'Manage Service Representatives', link: '/manage-s-a' },
        { value: 'Manage Work Items', link: '/manage-work-items' },
        { value: 'Reports', link: '/reports' }
      ];
      this.router.navigateByUrl('/admin-home');
    } else if (userType === 'SERVICE_ADVISOR') {
      this.panelName = 'Service Advisor Panel';
      this.navItems = [
        { value: 'Scheduled Vehicles', link: '/service-records' },
        { value: 'Reports', link: '/report' }
      ];
      this.router.navigateByUrl('/service-advisor-home');
    } else {
      this.redirectToLogin();
    }
  }

  logout(): void {
    this.apiService.logout();
    this.redirectToLogin();
  }

  private redirectToLogin(): void {
    this.panelName = 'Auth Panel';
    this.navItems = [];
    this.router.navigateByUrl('/login');
  }

  ngOnDestroy(): void {
    // Clean up the subscription to prevent memory leaks
    if (this.userStatusSubscription) {
      this.userStatusSubscription.unsubscribe();
    }
  }

  trackByFunction(index: number, item: NavigationItem): string {
    return item.link; // or any unique identifier of your items
  }
}
