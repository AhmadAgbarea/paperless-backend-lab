import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public currencyResult?: CurrencyResult;
  selectedMonth : number = 11;
  selectedYear: number = 21;
  http: HttpClient;
  onSubmit() {
    this.http.get<CurrencyResult>('/api/currency/'+this.selectedYear + this.selectedMonth).subscribe(result => {
      this.currencyResult = result;
      console.log(result.graph);
    }, error => console.error(error));
  }

  constructor(http: HttpClient) {
    this.http = http;
  }

  title = 'WebApp';
}

export interface CurrencyResult {
  graph: Record<string, number>
  min: number
  max: number
}