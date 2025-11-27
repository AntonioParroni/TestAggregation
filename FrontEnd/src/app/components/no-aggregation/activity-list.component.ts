import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface ActivitiesDTO {
  project: string;
  employment: string;
  date: string;
  hours: number;
}

@Component({
  selector: 'app-activity-list',
  templateUrl: './activity-list.component.html'
})
export class ActivityListComponent implements OnInit {

  activities: ActivitiesDTO[] = [];
  loading = true;

  private baseUrl = 'https://localhost:7268';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadNoAggregation();
  }

  loadNoAggregation(): void {
    this.http
      .get<ActivitiesDTO[]>(`${this.baseUrl}/Activities`)
      .subscribe({
        next: (data) => {
          this.activities = data;
          this.loading = false;
        },
        error: (err) => {
          console.error('Error loading data', err);
          this.loading = false;
        }
      });
  }
}
