import { Component, OnInit} from '@angular/core';
import { HttpService} from '../http.service';

interface Country {
  id: number;
  name: string;
}

interface Province {
  id: number;
  name: string;
}
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [HttpService]
})
export class RegistrationComponent implements OnInit  {
  login = "";
  password = "";
  confirmPassword = "";
  agreement = false;
  countries: Country[] = [];

  selectedCountry = 0;
  
  provinces: Province[] = [];

  selectedProvince = 0;
  
  constructor(private httpService: HttpService){}

  ngOnInit(){
    this.httpService.getCountries().subscribe({next: (data: any) => this.countries=data});
  }
  
  getCountryProvinces(selectedCountry: number){
    this.httpService.getCountryProvinces(selectedCountry).subscribe({next: (data: any) => this.provinces=data});
  }

  countrySelected(event: any) {
    if (event.value) {
      this.getCountryProvinces(event.value); 
    }
  }

  createUser() {
    let newUser = {
      Login: this.login,
      Password: this.password,
      CountryId: this.selectedCountry,
      ProvinceId: this.selectedProvince
    }

    this.httpService.postUser(newUser); 
  }
}