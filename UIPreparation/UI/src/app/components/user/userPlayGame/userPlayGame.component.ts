import { QuizTaker } from 'src/app/models/QuizTaker';
import { QuestionModelView } from 'src/app/models/QuestionModelView';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SignalRService } from 'src/app/services/signalR.service';
import { QuizTakerService } from 'src/app/services/quizTaker.service';
import { QuizService } from 'src/app/services/quiz.service';
import { QuizModelView } from 'src/app/models/QuizModelView';
import { Status } from 'src/app/models/Status';
import { AnswerType } from 'src/app/models/AnswerType';
import { timer } from 'rxjs';
import { QuizLocalation } from 'src/app/models/QuizLocalation';
@Component({
  selector: 'app-userPlayGame',
  templateUrl: './userPlayGame.component.html',
  styleUrls: ['./userPlayGame.component.css']
})
export class UserPlayGameComponent implements OnInit {
  quiz: QuizModelView = new QuizModelView();
  question: QuestionModelView = new QuestionModelView();

  quizNumber: string = "0";
  quizTakerId: string = "0";
  quizTaker: QuizTaker = new QuizTaker();
  quizTakerList: QuizTaker[] = [];
  userId: number = 0;

  questionLocalation: number = 0;
  quizLocalation: QuizLocalation = QuizLocalation.COUNTDOWN;
  answerType = AnswerType;
  userScore: number = 0;
  userAnswer: number = 6;
  countdown: number = 5;

  constructor(
    private activatedRoute: ActivatedRoute,
    private quizTakerService: QuizTakerService,
    private quizService: QuizService,
  ) { }

  ngOnInit(): void {
    localStorage.setItem("questionLocalation", this.questionLocalation.toString());
    this.quizTakerId = localStorage.getItem("GAMER");
    this.activatedRoute.params.subscribe(param => {
      this.quizNumber = param["quizNumber"];
      this.getQuiz();
    });

  }
  getQuiz() {
    this.quizService.getQuizByQuizNumberAndStatus(this.quizNumber, Status.STARTED).subscribe(response => {
      this.quiz = response.data;
      this.startQuestion();
    });
  }
  changeQuestion() {
    this.questionLocalation = this.questionLocalation + 1;
    localStorage.setItem("questionLocalation", this.questionLocalation.toString());
    this.question = new QuestionModelView();
    this.startQuestion();
  }

  startQuestion() {

    this.question = this.quiz.questions[this.questionLocalation];
    this.quizLocalation = QuizLocalation.COUNTDOWN;
    let countDownQUESTION = timer(0, 1000).subscribe(() => this.countdown--);
    setTimeout(() => {
      countDownQUESTION.unsubscribe();
      this.quizLocalation = QuizLocalation.QUESTION;
      let countDownSCORE = timer(0, 1000).subscribe(() => this.question.questionDuration--);
      setTimeout(() => {
        countDownSCORE.unsubscribe();
        this.getScoreList();
      }, this.question.questionDuration * 1000);
    }, this.countdown * 1000);
  }
  getScoreList() {
    this.quizTakerService.getAllQuizTakerByQuizNumber(this.quiz.quizNumber).subscribe(response => {
      this.quizTakerList = response.data.sort((a, b) => b.score - a.score);
      this.quizLocalation = QuizLocalation.RESULT;
    })
  }
  nextQuestion() {
    this.quizService.nextQuestion(this.questionLocalation, this.quiz).subscribe(response => {
      //this.questionLocalation=response;
      this.changeQuestion();
    });
  }
  completedQuiz(){
    this.quizService.completedQuiz(this.quiz).subscribe(response=>{
      this.quiz=response.data;
      this.quizLocalation = QuizLocalation.COMPLETED;
    })
  }

}
