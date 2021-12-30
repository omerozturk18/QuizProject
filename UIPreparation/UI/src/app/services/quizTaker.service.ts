import { ListResponseModel } from './../models/listResponseModel';
import { QuizTaker } from './../models/QuizTaker';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SingleResponseModel } from '../models/singleResponseModel';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root',
})
export class QuizTakerService {

  constructor(private httpClient: HttpClient) {}
  private employeesUrl = environment.baseUrl2 + 'api/QuizTakers';

  getEmployees(): Observable<any> {
    return this.httpClient.get<any>(this.employeesUrl+"/getAll")
      .pipe(
        catchError(this.handleError)
      );
  }
  isThereUserInQuiz(quizTaker: QuizTaker): Observable<SingleResponseModel<QuizTaker>> {
    return this.httpClient.post<SingleResponseModel<QuizTaker>>(environment.quizTakerPath+"/isThereUserInQuiz",quizTaker);
  }
  addQuizTaker(quizTaker: QuizTaker): Observable<SingleResponseModel<QuizTaker>> {
    return this.httpClient.post<SingleResponseModel<QuizTaker>>(environment.quizTakerPath+"/add?=",quizTaker);
  }
  updateQuizTaker(quizTaker:QuizTaker):Observable<SingleResponseModel<QuizTaker>>{
    return this.httpClient.post<SingleResponseModel<QuizTaker>>(environment.quizTakerPath+"/update",quizTaker);
  }
  deleteQuizTaker(quizTaker:QuizTaker):Observable<SingleResponseModel<QuizTaker>>{
    return this.httpClient.post<SingleResponseModel<QuizTaker>>(environment.quizTakerPath+"/delete",quizTaker);
  }
  getAllQuizTaker(): Observable<SingleResponseModel<QuizTaker[]>> {
    return this.httpClient.get<SingleResponseModel<QuizTaker[]>>(environment.quizTakerPath+"/getAll");
  }
  getQuizTaker(quizTakerId: string): Observable<SingleResponseModel<QuizTaker>> {
    return this.httpClient.get<SingleResponseModel<QuizTaker>>(environment.quizTakerPath+"/getById?quizTakerId="+quizTakerId);
  }
  getAllQuizTakerByQuizNumber(quizNumber: string): Observable<ListResponseModel<QuizTaker>> {
    return this.httpClient.get<ListResponseModel<QuizTaker>>(environment.quizTakerPath+"/getAllQuizTakerByQuizNumber?quizNumber="+quizNumber);
  }
  private handleError(err:any) {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}
