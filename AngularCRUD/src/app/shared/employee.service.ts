import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  formData : Employee;
  list : Employee[];
readonly rootURL="http://localhost:56437/api";
  constructor(private http: HttpClient) { }
  PostEmployee(formData : Employee) {
return this.http.post(this.rootURL+'/Employee',formData);
  }
  PutEmployee(formData : Employee) {
    return this.http.put(this.rootURL+'/Employee/'+formData.EmployeeID,formData);
      }
      DeleteEmployee(id : number) {
        return this.http.delete(this.rootURL+'/Employee/'+id);
          }
refreshList(){
  this.http.get(this.rootURL+'/Employee')
  .toPromise().then(res => this.list = res as Employee[]);
}

}
