import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UsercardsComponent } from './User/user/usercards/usercards.component';
import { UsermaintenanceComponent } from './User/user/usermaintenance/usermaintenance.component';
const routes: Routes = [
  {
    path: '',
    redirectTo: '/user/card',
    pathMatch: 'full',
  },
  {
    path: 'user',
    children: [
      { path: 'card', component: UsercardsComponent },
      {
        path: 'maintenance/:documentNumber',
        component: UsermaintenanceComponent,
      },
      { path: 'maintenance', component: UsermaintenanceComponent }, 
    ],
  },
  { path: '**', component: AppComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
