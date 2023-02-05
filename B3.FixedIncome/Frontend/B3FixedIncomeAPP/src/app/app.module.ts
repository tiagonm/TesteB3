import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { HomePageModule } from './pages/home/home.page.module';
import { ApiService } from './services/api.service';
import { HttpService } from './services/http.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AlertService } from './services/alert.service';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule, 
    HomePageModule,
    AppRoutingModule   
  ],
  providers: [
    ApiService,
    HttpService,
    AlertService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
