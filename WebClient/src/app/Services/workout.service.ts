import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Workout } from 'src/app/Interfaces/Classes';

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {
  private baseUrl: string = 'https://localhost:7125';

  constructor(private http: HttpClient) { }

  postWorkout(workout: Workout) {
    console.log(workout);
    return this.http.post<any>(`${this.baseUrl}/Workout`, workout);
  }
  getWorkout() {
    return this.http.get<any>(`${this.baseUrl}/Workout`);
  }
}
