import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../home/weather.service';

@Component({
  selector: 'app-history-component',
  templateUrl: './history.component.html'
})
export class HistoryComponent implements OnInit {

  history: any[] = [];
  constructor(private weatherService: WeatherService) {}

  ngOnInit(): void {
    this.loadHistory();
  }

  loadHistory() {
    this.weatherService.getWeatherHistory().subscribe(history => {
      this.history = history;
    })
  }

}
