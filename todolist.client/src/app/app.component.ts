import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface TodoItem {
  Id: number;
  Title: string;
  Description: string;
  Progressions: [];
  IsCompleted: boolean;
  PercentTotal: number;
}

interface Progression {
  Date: Date;
  Percent: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: TodoItem[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<TodoItem[]>('/api/TodoList').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'todolist.client';
}
