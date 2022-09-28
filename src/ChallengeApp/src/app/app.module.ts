import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CityFormComponent } from './city-form/city-form.component';
import { CityListComponent } from './city-list/city-list.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PersonFormComponent } from './person-form/person-form.component';
import { PersonListComponent } from './person-list/person-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    PersonFormComponent,
    PersonListComponent,
    CityFormComponent,
    CityListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PersonListComponent, pathMatch: 'full' },
      { path: 'form-person', component: PersonFormComponent },
      { path: 'list-city', component: CityListComponent },
      { path: 'form-city', component: CityFormComponent },
    ]),
    ReactiveFormsModule
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: () => "http://localhost:5194/" }  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
