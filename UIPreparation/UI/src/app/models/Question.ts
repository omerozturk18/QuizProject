import { QuestionType } from "./QuestionType";

export class Question{
  id:number;
  questionContent:string;
  questionImage:string;
  questionDuration:number;
  questionScore:number;
  isTimeOver:boolean;
  quizId:number;
  questionType: QuestionType;
}
