import { environment } from './../../../environments/environment';
import { Status } from './../../models/Status';
import { Quiz } from './../../models/Quiz';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { QuizService } from 'src/app/services/quiz.service';
import { QuizTakerService } from 'src/app/services/quizTaker.service';
import { QuizTaker } from 'src/app/models/QuizTaker';
import { QuizModelView } from 'src/app/models/QuizModelView';

@Component({
  selector: 'app-joinGame',
  templateUrl: './joinGame.component.html',
  styleUrls: ['./joinGame.component.css']
})
export class JoinGameComponent implements OnInit {
  quiz: QuizModelView = new QuizModelView();
  joinGameForm: FormGroup;
  isThereQuiz: boolean = false;
  quizStatus = Status;

  constructor(
    private formBuilder: FormBuilder,
    private quizService: QuizService,
    private toastrService: ToastrService,
    private quizTakerService: QuizTakerService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createJoinGameForm();
  }
  createJoinGameForm() {
    this.joinGameForm = this.formBuilder.group({
      quizNumber: ['', Validators.required],
      userName: [{ value: '', disabled: true }, Validators.required],
    });
  }
  isThereQuizCheck() {
    if (this.joinGameForm.valid) {
      this.quizService.isThereQuiz(this.joinGameForm.value.quizNumber).subscribe((response) => {
        this.quiz = response.data;
        localStorage.setItem("QUIZNUMBER", response.data.quizNumber);
        this.toastrService.success("Lütfen Kullanıcı Adı Giriniz");
        this.joinGameForm.controls.userName.enable();
      });
    } else this.toastrService.error("Zorunlu Alanı Doldur")

  }
  joinGame() {
    let quizTaker: QuizTaker = new QuizTaker();
    quizTaker.quizNumber = this.quiz.quizNumber;
    quizTaker.userName = this.joinGameForm.value.userName;
    quizTaker.questionId = "0";
    quizTaker.score = 0;
    this.quizTakerService.isThereUserInQuiz(quizTaker).subscribe((response) => {
      localStorage.setItem("GAMER", response.data.id);
      this.router.navigateByUrl("quizPreparation/" + this.quiz.quizNumber);
    });
  }
}
