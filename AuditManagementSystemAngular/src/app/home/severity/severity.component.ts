import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { auditRequest } from 'src/app/shared/auditRequest.model';
import { auditResponse } from 'src/app/shared/auditResponse.model';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-severity',
  templateUrl: './severity.component.html',
  styles: [
  ]
})
export class SeverityComponent implements OnInit {

 // public auditRespons:auditResponse=<auditResponse>{};
 public auditRespons:any;
  public audReq:auditRequest=<auditRequest>{};

  constructor(public service:UserService,private router:Router,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.auditRespons = this.service.auditres;
    this.audReq=this.service.gType;

    this.service.getUpdateSeverity().subscribe(res=>{
      if(res)
      {
        console.log(res);
        this.auditRespons=res;
      }
    })
  }


  onLogout() {
    localStorage.removeItem('token');
   
    this.router.navigate(['/login']);
  }


}
