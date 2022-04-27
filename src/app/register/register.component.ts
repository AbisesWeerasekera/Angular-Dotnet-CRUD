import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterService } from '../service/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  //if we make it private , the component.html can't access it.
  constructor(public _registerService:RegisterService) { }

  ngOnInit() {
    this.resetForm();
  }

  //when the form is loading we want to set the form value to initial values
  //we check the form object is null or not,then assign the input fileds to default values by using resetForm() funtion


  resetForm(form?:NgForm){
    if(form!=null){
      this.resetForm();
      this._registerService.formData={
        Id:0,
        Name:'',
        Age:0,
        Address:''
      }
    }
  }

}
