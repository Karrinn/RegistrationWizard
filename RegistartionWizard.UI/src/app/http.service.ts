import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

const baseUrl = 'https://localhost:7170';

@Injectable()
export class HttpService{
  
    constructor(private http: HttpClient){ }
      
    getCountries(){
        const countriesUrl = `${baseUrl}/countries`;
        return this.http.get(countriesUrl);
    }

    getCountryProvinces(countryId: number){
        const countryProvincessUrl = `${baseUrl}/countries/${countryId}/provincies`;

        return this.http.get(countryProvincessUrl);
    }

    postUser(body: any){
        const createUserUrl = `${baseUrl}/users`;

        return this.http.post(createUserUrl, body)
        .subscribe(
          (response) => {
            alert('user added');
          },
          (error) => {
            alert(`error: ${error}`);
          }
        );;
    }
}