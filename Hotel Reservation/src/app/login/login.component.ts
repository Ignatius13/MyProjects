import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private _route: Router) {}
  ngOnInit(): void {}
  onFormSubmission(referenceForForm: NgForm) {
    if (
      referenceForForm.value.userName === 'user@123' &&
      referenceForForm.value.password === 'igna@123'
    ) {
      this._route.navigate(['table']);
    }
  }
  onFormSubmit() {}
}
