import { QuestionOptionModalView } from './QuestionOptionModalView';
import { AnswerType } from './AnswerType';
import { QuestionType } from "./QuestionType";

export class QuestionModelView {
  id: string;
  questionContent: string;
  questionImage: string;
  questionDuration: number;
  questionScore: number;
  questionOptions: QuestionOptionModalView;
  questionType: QuestionType;
  correctAnswer:AnswerType;
}
