import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-preguntas-frecuentes',
  templateUrl: './preguntas-frecuentes.component.html',
  styleUrls: ['./preguntas-frecuentes.component.css']
})
export class PreguntasFrecuentesComponent implements OnInit {
  public qtdLluvia: any;
  public qtdSequia: any;
  public qtdOptimo: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any[]>(baseUrl + 'api/weather/lluvia').subscribe(result => {
      this.qtdLluvia = result;
    }, error => console.error(error));
    http.get<any[]>(baseUrl + 'api/weather/sequia').subscribe(result => {
      this.qtdSequia = result;
    }, error => console.error(error));
    http.get<any[]>(baseUrl + 'api/weather/optimo').subscribe(result => {
      this.qtdOptimo = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
