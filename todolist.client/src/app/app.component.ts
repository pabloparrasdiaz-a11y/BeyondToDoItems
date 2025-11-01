import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface TodoItem {
  id: number;
  title: string;
  description: string;
  category: string;
  progressions: Progression[];
  isCompleted: boolean;
  totalPercent: number;
}

interface Progression {
  date: Date;
  percent: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public todoItems: TodoItem[] = [];
  Math = Math;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getTotoItems();
  }

  getTotoItems() {
    this.http.get<TodoItem[]>('/api/TodoList').subscribe(
      (result) => {
        this.todoItems = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'todolist.client';
}
