import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Register } from '../models/register.model';
import { RegisterService } from '../service/register.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userList: {};

  //if we make it private , the component.html can't access it.
  constructor(public _registerService: RegisterService,private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
    this.loadUsers();
  }

  //when the form is loading we want to set the form value to initial values
  //we check the form object is null or not,then assign the input fileds to default values by using resetForm() funtion


  resetForm(form?: NgForm) {
    if (form != null) {
      this.resetForm();
      this._registerService.formData = {
        Id: 0,
        Name: '',
        Age: 0,
        Address: ''
      }
    }
  }

  loadUsers() {
    this._registerService.loadUsers().subscribe(
      data => {
        this.userList = data as Register;
        console.log(this.userList, "Display users");
      }
    )
  }

  OnSubmit(form: NgForm) {
    if (this._registerService.formData.Id == 0) {
      //--insert
      this.InsertUser();
    } else {
      //--update
      this.UpdateUser();
    }
    this.resetForm();
  }

  InsertUser() {
    this._registerService.InsertUser().subscribe(
      (res: any) => {
        this.toastr.success("Record Inserted","User Registration");
        this.loadUsers();
        console.log("Success");
      },
      (err) => {
        console.log(err);
      }
    );
  }

  UpdateUser() {
    this._registerService.InsertUser().subscribe(
      (res: any) => {
        this.toastr.info("Record Updated","User Registration");
        this.loadUsers();
        console.log("Success");
      },
      (err) => {
        console.log(err);
      }
    );
  }

  Toform(user) {
    // assigne user object to the formData object in service
    this._registerService.formData = Object.assign({}, user);
  }

  DeleteUser(Id) {
    if(confirm("Are you sure")){
      this._registerService.DeleteUser(Id).subscribe(
        (res: any) => {
          this.toastr.warning("Record Inserted","User Registration");
          console.log("deleted");
          this.loadUsers();
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }

}
