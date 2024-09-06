import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmpAddComponent } from './MyComponents/emp-add/emp-add.component';
import { EmpListComponent } from './MyComponents/emp-list/emp-list.component';
import { EmpUpdateComponent } from './MyComponents/emp-update/emp-update.component';
import { EmpDeleteComponent } from './MyComponents/emp-delete/emp-delete.component';

const routes: Routes = [
  { path: 'emplist', component: EmpListComponent },
  { path: 'empadd', component: EmpAddComponent },
  { path: 'empdelete', component: EmpDeleteComponent },
  { path: 'empupdate/:id', component: EmpUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
