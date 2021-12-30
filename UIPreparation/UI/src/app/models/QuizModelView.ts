import { QuestionModelView } from './QuestionModelView';
import { Status } from "./Status";

export class QuizModelView {
  id: string;
  userId: number;
  quizName: string;
  quizNumber: string;
  questions: QuestionModelView[];
  operationDate: Date;
  status: Status;
}
export enum OperationType{
  SAVE,
  UPDATE
}
