import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ClientRevenueIndexComponent } from './client-revenue/client-revenue-index/client-revenue-index.component';
import { ClientComponent } from './client-revenue/client/client.component';
import { ClientAuditComponent } from './client-revenue/client-audit/client-audit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClientRevenueIndexComponent,
    ClientComponent,
    ClientAuditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'client-index', component: ClientRevenueIndexComponent },
      { path: 'add', component: ClientComponent },
      { path: 'update/:id', component: ClientComponent },
      { path: 'audit/:id', component: ClientAuditComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
