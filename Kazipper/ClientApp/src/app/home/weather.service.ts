import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class WeatherService {
  constructor(private http: HttpClient) {}

  getWeather(zip: string) {
    return this.http.get('https://localhost:7013/weather/zip/' + zip);
  }

  getWeatherHistory() {
    return this.http.get<any[]>('https://localhost:7013/weather/history');
  }
}