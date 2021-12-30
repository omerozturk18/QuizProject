import { OperationType } from './../../../models/QuizModelView';
import { QuestionModelView } from './../../../models/QuestionModelView';
import { QuestionService } from './../../../services/question.service';
import { Quiz } from './../../../models/Quiz';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Question } from 'src/app/models/Question';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { QuizModelView } from 'src/app/models/QuizModelView';

@Component({
  selector: 'app-questionList',
  templateUrl: './questionList.component.html',
  styleUrls: ['./questionList.component.css']
})
export class QuestionListComponent implements OnInit {
  @Input() quiz: QuizModelView;
  @Output() saveQuiz = new EventEmitter();

  question: QuestionModelView = new QuestionModelView();
  operationType: OperationType = OperationType.SAVE;

  constructor(
    private toastrService: ToastrService,
    private router: Router,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
  }

  addQuestion(content: any) {
    this.operationType = OperationType.SAVE;
    this.modalService.open(content, {
      size: <any>"xl",
    });
  }

  editQuestion(content: any, questionn: QuestionModelView) {
    this.operationType = OperationType.UPDATE;
    this.question = questionn
    this.modalService.open(content, {
      size: <any>"xl",
    });
  }

  deleteQuestion(question: QuestionModelView) {
    this.quiz.questions = [...this.quiz.questions.filter(x => x != question)];
  }

  next() {
    this.saveQuiz.emit(this.quiz)
  }

  //Update Question Component Output
  updateQuestion(newQuestion: QuestionModelView) {
    console.log(newQuestion);
    this.question = newQuestion;
    this.modalService.dismissAll();
  }
  saveQuestion(question: QuestionModelView) {
    console.log(question);
    this.quiz.questions.push(question);
    this.modalService.dismissAll();
  }
}
