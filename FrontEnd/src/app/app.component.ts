import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
  HttpClientModule,
  CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'FrontEnd';
  catArray:Cat[] = [];



  constructor(public http:HttpClient) {
  }

  ngOnInit() {
    this.http.get<Cat[]>('https://localhost:7050/api/Cats').subscribe(res => {
      console.log(res);
      this.catArray = res;
    });
  }


}

export class Cat{
  constructor(public name:string, public image:string) {
  }
}
