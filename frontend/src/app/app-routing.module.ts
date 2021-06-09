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

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch:'full'},
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'customers', component: CustomerComponent},
  { path: 'plz', component: PlzComponent },
  { path: 'documents', component: DocumentComponent },
  { path: 'users', component: UserComponent },
  { path: 'article', component: ArticleComponent },
  { path: 'article-unit', component: ArticleUnitComponent },
  { path: 'tax-rate', component: TaxRateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
