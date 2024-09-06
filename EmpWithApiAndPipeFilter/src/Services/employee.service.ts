import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Department } from 'src/Models/Department';
import { Employee } from 'src/Models/Emp';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  Dept: Department;
  depts: Department[];
  emp: Employee;
  emps: Employee[];

  empreq: string = "https://localhost:7138/api/Emp";
  depreq: string = "https://localhost:7138/api/Dept";

  //Method to get the list of all employees from the API.
  getAllEmps(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.empreq);
  }

  getallDepts(): Observable<Department[]> {
    return this.http.get<Department[]>(this.depreq);
  }

  getempbyid(id: number): any {
    console.log("getempbyid method invoked");
    return this.http.get<Employee>(`${this.empreq}/${id}`);

  }

  createEmp(employee: Employee): Observable<Employee> {
    console.log("createEmp method called");
    console.log(employee);
    return this.http.post<Employee>(this.empreq, employee, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json;charset=UTF-8',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Method': '*'

      })
    });
  }

  //Method to update an existing employee.
  updateEmp(id: number, employee: Employee): Observable<any> {

    console.log(`${this.empreq}/${id}`);

    return this.http.put<any>(`${this.empreq}/${id}`, employee, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json;charset=UTF-8',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Method': '*'
      })
    });
  }


  //Method to delete an existing employee.
  deleteEmp(id: number): Observable<any> {
    return this.http.delete<any>(`${this.empreq}/${id}`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json;charset=UTF-8',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Method': '*'
      })
    });
  }

  //Method to test error handling.
  register(): Observable<any> {
    //Giving incorrect URL.
    return this.http.get<any>('https://localhost:7138/api/Emp')
      .pipe(catchError(this.manageError));
  }


  //Method to handle errors.
  private manageError(err_response: HttpErrorResponse) {
    if (err_response.error instanceof ErrorEvent)
      console.error('Client Side Error:', err_response.error.message);
    else
      console.error('Server Side Error:', err_response);

    return throwError('There is a little problem while processing your request. Sorry for the inconvenience');

  }




}
