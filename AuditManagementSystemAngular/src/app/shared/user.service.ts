import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { LoginModel } from './login-model.model';
import { getTypeDetail } from './getDetails.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { auditRequest } from './auditRequest.model';
import { GetAuditType } from './get-audit-type.model';
import { GetAuditTypeRes } from './get-audit-type-res.model';
import { auditResponse } from './auditResponse.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:23483/api'; 
  //http://localhost:23130
  //https://localhost:44333
  //http://localhost:23483


//login
  formData:LoginModel=new LoginModel();
//audittype
  getType:GetAuditType=new GetAuditType();
  public gType2:GetAuditTypeRes=<GetAuditTypeRes>{};

//checklist
  getTypeDetails:getTypeDetail=new getTypeDetail();
  public gType:auditRequest=<auditRequest>{};


//response
  public auditres:auditResponse=<auditResponse>{};

  //public updateSeverity;



  private updateSeverity = new BehaviorSubject<any>(null);

  currentSeverity = this.updateSeverity;


  setUpdateSeverity(severity){

    this.updateSeverity.next(severity);

  }

  getUpdateSeverity(): Observable<any>{

    return this.currentSeverity;

  }




  formModelType=this.fb.group({
   
    audittype: ['']
    
  });


  login(formData) {
    return this.http.post(this.BaseURI + '/Home/Login', formData);
  }
  
  audittype():Observable<any>
  {
    //return this.http.get(this.BaseURI + '/Home/AuditType', formData);

    const headers = new HttpHeaders().set('Content-Type','application/json');
    return this.http.post(this.BaseURI + '/Home/checklist',this.getType,{'headers':headers});
  }


  checklist(payload):Observable<any>
  {
    const headers = new HttpHeaders().set('Content-Type','application/json');
    return this.http.post(this.BaseURI + '/Home/severity',payload,{'headers':headers});
  }





}


