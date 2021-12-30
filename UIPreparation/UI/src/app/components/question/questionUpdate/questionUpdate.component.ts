import { OperationType } from './../../../models/QuizModelView';
import { AnswerType } from 'src/app/models/AnswerType';
import { QuestionOptionModalView } from 'src/app/models/QuestionOptionModalView';
import { QuestionModelView } from 'src/app/models/QuestionModelView';
import { QuestionType } from 'src/app/models/QuestionType';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-questionUpdate',
  templateUrl: './questionUpdate.component.html',
  styleUrls: ['./questionUpdate.component.css']
})
export class QuestionUpdateComponent implements OnInit {
  @Input() question: QuestionModelView;
  @Input() operationType: OperationType = 0;
  @Output() saveQuestion = new EventEmitter();
  @Output() updateQuestion = new EventEmitter();

  questionType = QuestionType;
  answerType = AnswerType;

  questionOptions: QuestionOptionModalView = new QuestionOptionModalView();
  questionForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
  ) { }

  ngOnInit() {
    this.createQuestionForm();
    if (this.operationType == OperationType.SAVE) {
      this.question = new QuestionModelView()
    } else {
      this.questionOptions = this.question.questionOptions;
    }
  }
  createQuestionForm() {
    this.questionForm = this.formBuilder.group({
      questionContent: ['', [Validators.required, Validators.minLength(5)]],
      questionImage: [''],
      questionDuration: [, Validators.required],
      questionScore: ['', Validators.required],
      questionType: ['1', Validators.required],
      correctAnswer: ['', Validators.required],
      answerA: [[Validators.required, Validators.minLength(3)]],
      answerB: [[Validators.required, Validators.minLength(3)]],
      answerC: [[Validators.required, Validators.minLength(3)]],
      answerD: [[Validators.required, Validators.minLength(3)]],
    });
  }

  save() {
    if (this.questionForm.valid) {
      this.question.questionOptions = new QuestionOptionModalView();
      this.question.questionOptions = this.questionOptions;
      this.saveQuestion.emit(this.question);
    } else {
      this.toastrService.error("Zorunlu Alanları Doldurunuz.")
    }
  }
  update() {
    if (this.questionForm.valid) {
      this.question.questionType == QuestionType.TRUEORFALSE ?
        this.question.questionOptions = null :
        this.question.questionOptions = this.questionOptions;
        this.question.correctAnswer=1;
      this.updateQuestion.emit(this.question);
    } else {
      this.toastrService.error("Zorunlu Alanları Doldurunuz.")
    }
  }
  getQuestion() {

  }
  changeQuestionType() {
    if (this.question.questionType == 0) {
      this.questionForm.controls.answerA.disable();
      this.questionForm.controls.answerB.disable();
      this.questionForm.controls.answerC.disable();
      this.questionForm.controls.answerD.disable();
      this.questionForm.controls.answerD.disable();
      this.question.questionType = QuestionType.TRUEORFALSE;
    } else {
      this.questionForm.controls.answerA.enable();
      this.questionForm.controls.answerB.enable();
      this.questionForm.controls.answerC.enable();
      this.questionForm.controls.answerD.enable();
      this.question.questionType = QuestionType.MULTIPLE;
    }
    this.question.correctAnswer = null;
    this.questionOptions = new QuestionOptionModalView();
  }

}
