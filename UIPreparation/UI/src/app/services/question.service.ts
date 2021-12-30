import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SingleResponseModel } from '../models/singleResponseModel';
import { Question } from '../models/Question';
import { QuestionModelView } from '../models/QuestionModelView';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private httpClient:HttpClient) { }

  add(question:Question):Observable<SingleResponseModel<Question>>{
    return this.httpClient.post<SingleResponseModel<Question>>(environment.questionPath+"/add",question);
  }
  addQuestion(question:Question):Observable<SingleResponseModel<Question>>{
    return this.httpClient.post<SingleResponseModel<Question>>(environment.questionPath+"/addQuestion",question);
  }
  // addQuestions(questions:Question[]):Observable<SingleResponseModel<Question[]>>{
  //   return this.httpClient.post<SingleResponseModel<Question[]>>(environment.questionPath+"/addQuestions",questions);
  // }

  updateQuestion(question:Question):Observable<SingleResponseModel<Question>>{
    return this.httpClient.post<SingleResponseModel<Question>>(environment.questionPath+"/update",question);
  }
  deleteQuestion(question:Question):Observable<SingleResponseModel<Question[]>>{
    return this.httpClient.post<SingleResponseModel<Question[]>>(environment.questionPath+"/delete",question);
  }
  getAllQuestions(): Observable<SingleResponseModel<Question[]>> {
    return this.httpClient.get<SingleResponseModel<Question[]>>(environment.questionPath+"/getAll");
  }
  getQuestion(questionId: number): Observable<SingleResponseModel<Question>> {
    return this.httpClient.get<SingleResponseModel<Question>>(environment.questionPath+"/getById?questionId="+questionId);
  }
  getQuestionsByQuizId(quizId: number): Observable<SingleResponseModel<Question[]>> {
    return this.httpClient.get<SingleResponseModel<Question[]>>(environment.questionPath+"/getQuestionsByQuizId?quizId="+quizId);
  }
  getQuestionsDetailByQuizId(quizId: number): Observable<SingleResponseModel<QuestionModelView[]>> {
    return this.httpClient.get<SingleResponseModel<QuestionModelView[]>>(environment.questionPath+"/getQuestionsDetailByQuizId?quizId="+quizId);
  }
}
