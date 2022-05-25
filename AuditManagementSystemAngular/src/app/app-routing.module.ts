import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuditTypeComponent } from './home/audit-type/audit-type.component';
import { ChecklistComponent } from './home/checklist/checklist.component';
import { HomeComponent } from './home/home.component';
import { SeverityComponent } from './home/severity/severity.component';
import { LoginComponent } from './user/login/login.component';
//import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';



const routes: Routes = [
  {path:'',redirectTo:'/login',pathMatch:'full'},
  
     { path: 'login', component: LoginComponent },
      {path:'home',component:HomeComponent},
      {path:'home/audittype',component:AuditTypeComponent},
      {path:'home/checklist',component:ChecklistComponent},
      {path:'home/severity',component:SeverityComponent},
];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
