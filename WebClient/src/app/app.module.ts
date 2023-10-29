import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CreateWorkoutComponent } from './components/create-workout/create-workout.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LabelCheckboxComponent } from './Directives/component-directives/label-checkbox/label-checkbox.component';
import {HttpClientModule } from '@angular/common/http'

const appRoutes: Routes = [
  { path: 'Skapa', component: CreateWorkoutComponent },
  { path: '', component: HomeComponent },

];


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CreateWorkoutComponent,
    HomeComponent,
    LabelCheckboxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
