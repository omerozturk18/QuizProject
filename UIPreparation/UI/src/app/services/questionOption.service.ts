import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SingleResponseModel } from '../models/singleResponseModel';
import { QuestionOption } from '../models/QuestionOption';

@Injectable({
  providedIn: 'root'
})
export class QuestionOptionService {

  constructor(private httpClient:HttpClient) { }

  addQuestionOption(questionOption:QuestionOption):Observable<SingleResponseModel<QuestionOption>>{
    return this.httpClient.post<SingleResponseModel<QuestionOption>>(environment.questionOptionPath+"/add",questionOption);
  }
  addQuestionOptions(questionOptions:QuestionOption[]):Observable<SingleResponseModel<QuestionOption[]>>{
    return this.httpClient.post<SingleResponseModel<QuestionOption[]>>(environment.questionOptionPath+"/multiAdd",questionOptions);
  }
  updateQuestionOptions(questionOptions:QuestionOption[]):Observable<SingleResponseModel<QuestionOption[]>>{
    return this.httpClient.post<SingleResponseModel<QuestionOption[]>>(environment.questionOptionPath+"/multiUpdate",questionOptions);
  }
  updateQuestionOption(questionOption:QuestionOption):Observable<SingleResponseModel<QuestionOption>>{
    return this.httpClient.post<SingleResponseModel<QuestionOption>>(environment.questionOptionPath+"/update",questionOption);
  }
  deleteQuestionOption(questionOption:QuestionOption):Observable<SingleResponseModel<QuestionOption>>{
    return this.httpClient.post<SingleResponseModel<QuestionOption>>(environment.questionOptionPath+"/delete",questionOption);
  }
  getAllQuestionOptions(): Observable<SingleResponseModel<QuestionOption[]>> {
    return this.httpClient.get<SingleResponseModel<QuestionOption[]>>(environment.questionOptionPath+"/getAll");
  }
  getQuestionOptionsByQuestionId(questionId: number): Observable<SingleResponseModel<QuestionOption[]>> {
    return this.httpClient.get<SingleResponseModel<QuestionOption[]>>(environment.questionOptionPath+"/getQuestionOptionsByQuestionId?questionId="+questionId);
  }
}
