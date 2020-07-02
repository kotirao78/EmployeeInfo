import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../shared/employee.service';
import { NgForm } from '../../../../node_modules/@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.less']
})
export class EmployeeComponent implements OnInit {

  constructor(public _employeeService : EmployeeService,
    public toaster: ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
  }
resetForm(form? : NgForm){
if (form != null)
  form.resetForm();
  this._employeeService.formData = {
    EmployeeID : null,
    FullName : '',
    EmpCode: '',
    Mobile: '',
    Position: ''
}

}
onSubmit(form : NgForm) {
  if(form.value.EmployeeID == null)
  this.insertRecord(form);
  else
  this.updateRecord(form);
}
insertRecord(form : NgForm){
  this._employeeService.PostEmployee(form.value).subscribe(res => {
   this.toaster.success('Inserted Successfully','EMP Register');
    this.resetForm(form);
    this._employeeService.refreshList();
  });
}
updateRecord(form: NgForm){
  this._employeeService.PutEmployee(form.value).subscribe(res => {
this.toaster.success('Update Record Successfully','Emp Update');
this.resetForm(form);
this._employeeService.refreshList();
  });
}
}
