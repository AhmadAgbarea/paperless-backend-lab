import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar'; 
 import {MatIconModule} from '@angular/material/icon'; 
 import {MatInputModule} from '@angular/material/input'; 
 import {MatButtonModule} from '@angular/material/button'; 
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, FormsModule, BrowserAnimationsModule, MatToolbarModule , MatIconModule, MatInputModule, MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
