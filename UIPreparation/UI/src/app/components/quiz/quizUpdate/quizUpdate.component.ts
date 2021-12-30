import { AuthService } from './../../../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { QuizModelView } from 'src/app/models/QuizModelView';

@Component({
  selector: 'app-quizUpdate',
  templateUrl: './quizUpdate.component.html',
  styleUrls: ['./quizUpdate.component.css']
})
export class QuizUpdateComponent implements OnInit {
  @Input() quiz: QuizModelView = new QuizModelView();
  @Output() saveQuiz= new EventEmitter();

  quizForm: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private authService: AuthService,
  ) { }

  ngOnInit() {
    this.createQuizForm();
  }
  createQuizForm() {
    this.quizForm = this.formBuilder.group({
      quizName: ['', [Validators.required, Validators.minLength(5)]],
    });
  }
  save() {
    if (this.quizForm.valid) {
      let user=this.authService.getCurrentUser();
        this.quiz.userId=user.UserId;
        alert(user.UserId)
      this.saveQuiz.emit(this.quiz);
    }else{
      this.toastrService.error("Sınav İsmi Zorunludur.")
    }
  }
}
