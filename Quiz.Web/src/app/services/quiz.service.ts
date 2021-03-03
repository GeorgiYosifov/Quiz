import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IQuiz } from '../models/quiz/quiz';
import { IQuizCheck } from '../models/quiz/quiz-check';
import { IQuizResult } from '../models/quiz/quiz-result';

@Injectable()
export class QuizService {
  private API_URL = environment.API_URL;
  private readonly url = this.API_URL + '/quiz';

  constructor(private http: HttpClient) { }

  public getQuiz(quizId: number): Observable<IQuiz> {
    return this.http.get<IQuiz>(this.url + `/${quizId}`);
  }

  public createQuiz(): Observable<number> {
    const userId = localStorage.getItem('userId');
    return this.http.post<number>(this.url, userId);
  }

  public checkQuiz(body: IQuizCheck) {
    return this.http.patch<IQuizResult>(this.url, body);
  }
}
