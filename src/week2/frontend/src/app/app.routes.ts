import { Routes } from '@angular/router';
import { HomeComponent } from './components/home.component';

export const routes: Routes = [
  {
    path: 'dashboard',
    component: HomeComponent,
  },
  {
    path: 'banking',
    loadChildren: () =>
      import('./banking/banking.routes').then((r) => r.BANKING_ROUTES),
  },
  {
    path: '**', // Redirect to everyone, works like a switch statement default
    redirectTo: 'dashboard',
  },
];
