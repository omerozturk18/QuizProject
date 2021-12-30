import { Status } from 'src/app/models/Status';
import { Quiz } from './../models/Quiz';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SingleResponseModel } from '../models/singleResponseModel';
import { ListResponseModel } from '../models/listResponseModel';
import { QuizModelView } from '../models/QuizModelView';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private httpClient: HttpClient) { }

  isThereQuiz(quizNumber: string): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.get<SingleResponseModel<QuizModelView>>(environment.quizPath + "/isThereQuiz?quizNumber=" + quizNumber);
  }
  addQuiz(quiz: QuizModelView): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.post<SingleResponseModel<QuizModelView>>(environment.quizPath + "/add", quiz);
  }
  updateQuiz(quiz: QuizModelView): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.post<SingleResponseModel<QuizModelView>>(environment.quizPath + "/update", quiz);
  }
  deleteQuiz(quiz: QuizModelView): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.post<SingleResponseModel<QuizModelView>>(environment.quizPath + "/delete", quiz);
  }
  getAllQuizzes(): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.get<SingleResponseModel<QuizModelView>>(environment.quizPath + "/getAll");
  }
  getQuiz(quizId: string): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.get<SingleResponseModel<QuizModelView>>(environment.quizPath + "/getById?quizId=" + quizId);
  }
  getUserQuizzes(userId: number): Observable<SingleResponseModel<QuizModelView[]>> {
    return this.httpClient.get<SingleResponseModel<QuizModelView[]>>(environment.quizPath + "/getByUserQuizzes?userId=" + userId);
  }
  getQuizByQuizNumberAndStatus(quizNumber: string,status:Status): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.get<SingleResponseModel<QuizModelView>>
    (environment.quizPath + "/getQuizByQuizNumber?quizNumber=" + quizNumber+"&status=" + status);
  }
  getQuizzesDetailByUserId(userId: number): Observable<ListResponseModel<QuizModelView>> {
    return this.httpClient.get<ListResponseModel<QuizModelView>>(environment.quizPath + "/getQuizzesDetailByUserId?userId=" + userId);
  }
  activatedQuiz(quiz: QuizModelView): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.post<SingleResponseModel<QuizModelView>>(environment.quizPath + "/activatedQuiz", quiz);
  }
  startedQuiz(quiz: QuizModelView): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.post<SingleResponseModel<QuizModelView>>(environment.quizPath + "/startedQuiz", quiz);
  }
  completedQuiz(quiz: QuizModelView): Observable<SingleResponseModel<QuizModelView>> {
    return this.httpClient.post<SingleResponseModel<QuizModelView>>(environment.quizPath + "/completedQuiz", quiz);
  }
  nextQuestion(questionLocalation:number,quiz: QuizModelView): Observable<number> {
    return this.httpClient.post<number>(environment.quizPath + "/nextQuestion?questionLocalation="+questionLocalation, quiz);
  }
}
