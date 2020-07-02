import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { Employee } from 'src/app/shared/employee.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.less'],
})
export class EmployeeListComponent implements OnInit {
  constructor(public service: EmployeeService,private toaster: ToastrService) {}

  ngOnInit() {
   
    this.service.refreshList();
  }
  populateForm(emp: Employee) {
    this.service.formData = Object.assign({},emp);
  }
  onDelete(id :number){
    if (confirm('Are you sure want to Delete?')){

    
    this.service.DeleteEmployee(id).subscribe(res => {
      this.service.refreshList();
      this.toaster.warning('Deleted Record','Emp Delete');

    });
  }
  }
}
