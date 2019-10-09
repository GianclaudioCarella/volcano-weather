import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-api-connection',
  templateUrl: './api-connection.component.html',
  styleUrls: ['./api-connection.component.css']
})
export class ApiConnectionComponent implements OnInit {

  _result: any;
  _baseUrl: any;
  _http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this._http = http;
  }

  ngOnInit() {

  }

  generaDatos() {
    console.log('llamado api');
    this._http.post(this._baseUrl + 'api/weather', null).subscribe(
      (response) => {
        return response;
      }
    )
  }


}
