import { Component } from '@angular/core';

interface Country {
  value: string;
  viewValue: string;
}

interface Province {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-step2',
  templateUrl: './step2.component.html',
  styleUrls: ['./step2.component.css']
})

export class Step2Component {
  countries: Country[] = [
    {value: '1', viewValue: 'Russia'},
    {value: '2', viewValue: 'USA'},
  ];

  selectedCountry = '';
  
  provinces: Province[] = [];

  selectedProvince = '';
}