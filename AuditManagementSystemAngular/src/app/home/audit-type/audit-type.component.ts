import { formatCurrency } from '@angular/common';
import { HttpClient, HttpHeaderResponse, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-audit-type',
  templateUrl: './audit-type.component.html',
  styles: [
  ]
})
export class AuditTypeComponent implements OnInit {

  contactForm:FormGroup;
 
  auditTypes = [
    { id: 1, name: "Internal" },
    
  ];

  constructor( private fb:FormBuilder,public service: UserService,private router: Router,private toastr:ToastrService) { }

  ngOnInit(){
    /*
    this.contactForm = this.fb.group({
    auditType: [null]
  });
  */
}

submit() {
  console.log("Form Submitted")
  console.log(this.contactForm.value)
}



onSubmit(form:NgForm)
  {
    this.service.audittype().subscribe(
      res=>{
        this.service.gType2=this.service.getType;
        this.router.navigateByUrl("/home/checklist");
        //this.service.pres = res;
        //console.log(this.service.res);
        console.log(this.service.getType);
         //this.toastr.success('Details Created Successfully');
         // this.router.navigate(['checklist'], { skipLocationChange: true });

      }
    );
  }

  onLogout() {
    localStorage.removeItem('token');
   
    this.router.navigate(['/login']);
  }







/*
onSubmit(form: NgForm) {
  this.service.audittype(form.value).subscribe(
    (res: any) => {
      this.router.navigateByUrl('/home/checklist');
    },

  );
}

*/



}
