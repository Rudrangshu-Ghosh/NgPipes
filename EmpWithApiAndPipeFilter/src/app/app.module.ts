import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { EmpAddComponent } from './MyComponents/emp-add/emp-add.component';
import { EmpListComponent } from './MyComponents/emp-list/emp-list.component';
import { EmpUpdateComponent } from './MyComponents/emp-update/emp-update.component';
import { EmpDeleteComponent } from './MyComponents/emp-delete/emp-delete.component';
import { DeptPipe, SalPipe } from './MyComponents/emp-pipe';


@NgModule({
  declarations: [
    AppComponent,
    EmpAddComponent,
    EmpListComponent,
    EmpUpdateComponent,
    EmpDeleteComponent,
    SalPipe,
    DeptPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
