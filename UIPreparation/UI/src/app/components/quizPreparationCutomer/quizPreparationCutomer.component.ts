import { QuizTaker } from 'src/app/models/QuizTaker';
import { QuizTakerService } from './../../services/quizTaker.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SignalRService } from 'src/app/services/signalR.service';
import { QuizService } from 'src/app/services/quiz.service';
import { Status } from 'src/app/models/Status';


@Component({
  selector: 'app-quizPreparationCutomer',
  templateUrl: './quizPreparationCutomer.component.html',
  styleUrls: ['./quizPreparationCutomer.component.css']
})
export class QuizPreparationCutomerComponent implements OnInit {
  quizNumber: string;
  quizTakerList: QuizTaker[] = [];
  errorMessage = '';

  constructor(
    private activatedRoute: ActivatedRoute,
    private signalRService: SignalRService,
    private quizTakerService: QuizTakerService,
    private quizService: QuizService,

    private router: Router
  ) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(param => {
      this.quizNumber = param["quizNumber"];
      this.quizService.getQuizByQuizNumberAndStatus(this.quizNumber, Status.ACTIVE).subscribe((response) => {
        this.getQuizTakerData();
        this.signalRService.changeQuizTaker.subscribe(() => this.getQuizTakerData());
        this.signalRService.startedQuiz.subscribe(() => this.startedQuiz());
      },error =>{
        this.router.navigateByUrl("");
      });
    });
  }
  getQuizTakerData() {
    this.quizTakerService.getAllQuizTakerByQuizNumber(this.quizNumber).subscribe(
      response => {
        this.quizTakerList = response.data;
      },
      error => this.errorMessage = <any>error
    );
  }
  startedQuiz() {
    this.router.navigateByUrl("playGame/" + this.quizNumber)
  }
}
