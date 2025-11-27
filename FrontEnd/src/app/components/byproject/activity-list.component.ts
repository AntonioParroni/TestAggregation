import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface ActivitiesDTO {
  projectName: string;
  totalHours: number;
}

@Component({
  selector: ' byprojcet-activity-list',
  templateUrl: './project-list.component.html'
})
export class ActivityByProjectListComponent implements OnInit {

  activities: ActivitiesDTO[] = [];
  loading = true;

  private baseUrl = 'https://localhost:7268';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadNoAggregation();
  }

  loadNoAggregation(): void {
    this.http
      .get<ActivitiesDTO[]>(`${this.baseUrl}/Activities/aggregation/by-project`)
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
