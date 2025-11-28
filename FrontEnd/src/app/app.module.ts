import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ManageComponent } from './components/manage/manage.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ActivityListComponent } from './components/no-aggregation/activity-list.component';
import { ActivityByProjectListComponent } from './components/byproject/activitylist.component';
import { ActivityByProjectAndEmployeeListComponent } from './components/byprojectandemployee/activitybyprojectandemployee-list.component';
import { ActivityByEmployeeAndProjectListComponent } from './components/byemployeeandproject/activitybyprojectandemployee-list.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    data: { title: 'Home', showInNav: true },
  },
  {
    path: 'manage',
    component: ActivityListComponent,
    data: { title: 'No Aggregation', showInNav: true },
  },
    {
    path: 'byproject',
    component: ActivityByProjectListComponent,
    data: { title: 'ByProject', showInNav: true },
  },
      {
    path: 'byprojectandemployee',
    component: ActivityByProjectAndEmployeeListComponent,
    data: { title: 'ByProjectAndEmployee', showInNav: true },
  },
        {
    path: 'bypemployeeandproject',
    component: ActivityByEmployeeAndProjectListComponent,
    data: { title: 'ByEmployeeAndProject', showInNav: true },
  },
  {
    path: '**',
    redirectTo: '',
  },
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    ManageComponent,
    ActivityListComponent,
    ActivityByProjectListComponent,
    ActivityByProjectAndEmployeeListComponent,
    ActivityByEmployeeAndProjectListComponent,
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
