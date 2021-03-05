import { Component, HostListener } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { IdentityService } from 'src/app/services/identity.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public form: FormGroup;

  constructor(private identityService: IdentityService,
    private fb: FormBuilder) { }

  ngOnInit() {
    localStorage.clear();
    this.form = this.fb.group({
      username: ['', Validators.required],
    })
  }

  public login() {
    this.identityService.login(this.form.value);
  }

  public get f() {
    return this.form.controls
  }
}