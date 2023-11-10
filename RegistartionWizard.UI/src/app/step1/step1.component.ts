import { Component } from '@angular/core';

const passwodValidationRegex = new RegExp("^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{2,}$");
const loginValidationRegex = new RegExp("^[A-Z0-9+_.-]+@[A-Z0-9.-]+$");

@Component({
  selector: 'app-step1',
  templateUrl: './step1.component.html',
  styleUrls: ['./step1.component.css']
})

export class Step1Component {
  login = "";
  password = "";
  confirmPassword = "";
  agreement = false;
  isStep2Disabled = !this.isLoginValid() || !this.isPasswordValid() || !this.isPasswordConfirmed();
  
  isLoginValid() {
    return loginValidationRegex.test(this.login);
  }
  
  isPasswordValid() {
    return passwodValidationRegex.test(this.password);
  }

  isPasswordConfirmed() {
    return this.password.localeCompare(this.confirmPassword) == 0;
  }

  goToStep2() {
    //this.tabs.focusTab(2);
  }
}
