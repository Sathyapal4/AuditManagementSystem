import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-checklist',
  templateUrl: './checklist.component.html',
  styles: [
  ]
})
export class ChecklistComponent implements OnInit {

  constructor(public service: UserService,private router: Router,private toastr:ToastrService) { }

  ngOnInit(): void {


  }


  onSubmit(form:NgForm)
  {
    this.service.checklist(this.service.getTypeDetails).subscribe(
      res=>{
        this.service.gType=this.service.getTypeDetails;
        this.service.auditres = res;
        console.log(this.service.auditres);
        

        this.service.setUpdateSeverity(res);

        console.log(this.service.getTypeDetails);
          this.toastr.success('Successfully Submitted');
         // this.router.navigate(['home','severity']);
         this.router.navigateByUrl('/home/severity');
      }
    );
  }



  onLogout() {
    localStorage.removeItem('token');
   
    this.router.navigate(['/login']);
  }

}
