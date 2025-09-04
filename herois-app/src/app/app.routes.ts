import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { HeroisComponent } from './pages/herois/herois.component';
import { HeroiFormComponent } from './pages/herois/heroi-form/heroi-form.component';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard'
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    path: 'herois',
    component: HeroisComponent,
  },
  {
    path: 'herois/novo',
    component: HeroiFormComponent,
  },
  {
    path: 'herois/:id/editar',
    component: HeroiFormComponent,
  }
];
