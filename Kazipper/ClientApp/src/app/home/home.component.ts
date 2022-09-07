import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { WeatherService } from './weather.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  weather: any;
  errorMessage: any;

  constructor(private weatherService: WeatherService) {}

  form = new FormGroup({
    zip: new FormControl(null, [Validators.required]),
  });

  getWeather() {
    console.log(this.form)
    const zip = this.form.controls.zip.value;
    this.errorMessage = null


    this.weatherService.getWeather(zip)
      .subscribe((weather) => {
        this.weather = weather;
      }, (err) => {
        this.errorMessage = 'An error occurred during processing your request. Try later.'
      })
  }

}
