import { Component, Input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

export type MenuItem = {
  icon: string;
  label: string;
  route: string;
}

@Component({
  selector: 'app-custom-sidenav',
  standalone: true,
  imports: [CommonModule, MatListModule, MatIconModule, RouterModule],
  templateUrl: './custom-sidenav.component.html',
  styleUrls: ['./custom-sidenav.component.scss']
})
export class CustomSidenavComponent {
  menuItems = signal<MenuItem[]>([
  {
    icon: 'home',
    label: 'Home',
    route: '/dashboard'
  },
  {
    icon: 'person',
    label: 'Heróis',
    route: '/herois'  
  }
  ]);

}
