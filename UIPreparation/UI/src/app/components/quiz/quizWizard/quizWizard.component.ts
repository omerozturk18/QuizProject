import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgWizardConfig, NgWizardService, THEME, TOOLBAR_POSITION } from 'ng-wizard';
import { ToastrService } from 'ngx-toastr';
import { QuestionModelView } from 'src/app/models/QuestionModelView';
import { QuizModelView } from 'src/app/models/QuizModelView';
import { Status } from 'src/app/models/Status';
import { QuizService } from 'src/app/services/quiz.service';

@Component({
  selector: 'app-quizWizard',
  templateUrl: './quizWizard.component.html',
  styleUrls: ['./quizWizard.component.css']
})
export class QuizWizardComponent implements OnInit {
  config: NgWizardConfig = {
    selected: 0,
    theme: THEME.circles,
    toolbarSettings: {
      showNextButton: false,
      showPreviousButton: false,
      toolbarPosition:TOOLBAR_POSITION.top,
      // toolbarExtraButtons: [
      //   {
      //     text: 'Önceki',
      //     class: 'btn btn-warning text-white',
      //     event: this.showPreviousStep.bind(this)
      //   },
      //   {
      //     text: 'İleri',
      //     class: 'btn btn-primary text-white',
      //     event: this.showNextStep.bind(this)
      //   },
      //   {
      //     text: 'Sıfırla',
      //     class: 'btn btn-danger',
      //     event: this.resetWizard.bind(this)
      //   },
      //   {
      //     text: 'Kaydet',
      //     class: 'btn btn-success',
      //     event: () => alert('Finished!!!')
      //   },

      // ]
    }
  };
  quiz: QuizModelView = new QuizModelView();
  quizId: string = "0";
  quizForm: FormGroup;
  constructor(
    private quizService: QuizService,
    private router: Router,
    private toastrService: ToastrService,
    private activatedRoute: ActivatedRoute,
    private ngWizardService: NgWizardService,
  ) { }

  ngOnInit() {
    this.quiz.questions=[];
    // this.ngWizardService.stepChanged()
    //   .subscribe({
    //     next: (args) => {
    //     }
    //   });
    this.activatedRoute.params.subscribe(param => {
      this.quizId = param["quizId"]
      this.quizId != "0" ? this.getQuiz() : "";
    })
  }
  updateQuestion(newQuiz:QuizModelView) {
    this.quiz=newQuiz;
  }
  saveQuestion(question:QuestionModelView) {
    this.quiz.questions.push(question);
  }
  saveQuiz(newQuiz:QuizModelView) {
    this.quiz=newQuiz;
    this.ngWizardService.next();
  }
  getQuiz() {
    this.quizService.getQuiz(this.quizId).subscribe(response => {
      this.toastrService.success(response.message);
      this.quiz = response.data;
    }, responseError => {
      this.toastrService.error(responseError.error)
    });
  }
  resetWizard(event?: Event) {
    this.ngWizardService.reset();
  }
  saveQuizService(){
    this.quiz.userId=5;
    this.quiz.status=Status.PASSIVE;
    this.quizService.addQuiz(this.quiz).subscribe(response=>{
      this.toastrService.success(response.message);
      this.router.navigate(["user","quizList"]);
    });
  }
  updateQuizService(){
    this.quiz.userId=5;
    this.quiz.status=Status.PASSIVE;
    this.quizService.updateQuiz(this.quiz).subscribe(response=>{
      this.toastrService.success(response.message);
      this.router.navigate(["user","quizList"]);
    });
  }
}
