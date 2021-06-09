import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './components/customer/customer.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DocumentComponent } from './components/document/document.component';
import { LoginComponent } from './components/login/login.component';
import { PlzComponent } from './components/plz/plz.component';
import { UserComponent } from './components/user/user.component';
import { ArticleComponent } from './components/article/article.component';
import { TaxRateComponent } from './components/tax-rate/tax-rate.component';
import { ArticleUnitComponent } from './components/article-unit/article-unit.component';

import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch:'full'},
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate:[AuthGuard]},
  { path: 'customers', component: CustomerComponent, canActivate:[AuthGuard]},
  { path: 'plz', component: PlzComponent, canActivate:[AuthGuard] },
  { path: 'documents', component: DocumentComponent, canActivate:[AuthGuard]},
  { path: 'users', component: UserComponent, canActivate:[AuthGuard]},
  { path: 'article', component: ArticleComponent, canActivate:[AuthGuard]},
  { path: 'article-unit', component: ArticleUnitComponent, canActivate:[AuthGuard]},
  { path: 'tax-rate', component: TaxRateComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
