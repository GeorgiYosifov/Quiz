import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICategory } from '../models/quiz/category';
import { IHistoryAnswer } from '../models/quiz/history-answer';
import { IQuiz } from '../models/quiz/quiz';
import { IQuizCheck } from '../models/quiz/quiz-check';
import { IQuizResult } from '../models/quiz/quiz-result';

@Injectable()
export class QuizService {
  private API_URL = environment.API_URL;
  private readonly url = this.API_URL + '/quiz';
  private readonly getHistoryUrl = this.API_URL + '/quiz/getOnlyThree';
  private readonly getCategoriesUrl = this.API_URL + '/quiz/getCategories';

  constructor(private http: HttpClient) { }

  public getQuiz(quizId: number): Observable<IQuiz> {
    return this.http.get<IQuiz>(this.url + `/${quizId}`);
  }

  public createQuiz(): Observable<number> {
    const userId = localStorage.getItem('userId');
    return this.http.post<number>(this.url, { userId });
  }

  public checkQuiz(body: IQuizCheck): Observable<IQuizResult> {
    return this.http.patch<IQuizResult>(this.url, body);
  }

  public getHistory(): Observable<IHistoryAnswer[]> {
    const userId = localStorage.getItem('userId');
    return this.http.get<IHistoryAnswer[]>(this.getHistoryUrl + `/${userId}`);
  }

  public getCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this.getCategoriesUrl);
  }
}
