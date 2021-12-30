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
import {  timer } from 'rxjs';
import { QuizLocalation } from 'src/app/models/QuizLocalation';

@Component({
  selector: 'app-playGame',
  templateUrl: './playGame.component.html',
  styleUrls: ['./playGame.component.css']
})
export class PlayGameComponent implements OnInit {
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
    private signalRService: SignalRService,
    private quizTakerService: QuizTakerService,
    private quizService: QuizService,
    private router: Router
  ) { }

  ngOnInit(): void {
      this.quizTakerId = localStorage.getItem("GAMER");
      this.quizTakerId==null?this.router.navigateByUrl(""):"";
      this.activatedRoute.params.subscribe(param => {
        this.quizNumber = param["quizNumber"];
        this.getQuiz();
        this.getQuizTaker();
        this.signalRService.changeQuestion.subscribe(() => this.changeQuestion());
        this.signalRService.completedQuiz.subscribe(() => this.completedQuiz());
      });
  }
  getQuiz() {
    this.quizService.getQuizByQuizNumberAndStatus(this.quizNumber, Status.STARTED).subscribe(response => {
      this.quiz = response.data;
      this.startQuestion();
    },error=>{
      this.router.navigateByUrl("")
    });
  }
  changeQuestion() {
    this.questionLocalation = this.questionLocalation + 1;
    localStorage.setItem("questionLocalation", this.questionLocalation.toString());
    this.question = new QuestionModelView();
    this.startQuestion();
  }
  answer(userAnswer: AnswerType) {
    this.quizLocalation = QuizLocalation.WAIT;
    this.userAnswer = userAnswer;
    this.question.correctAnswer == userAnswer ? this.userScore = (this.question.questionScore * this.question.questionDuration) : this.userScore = 0;
    this.quizTaker.score = this.quizTaker.score + this.userScore;
    this.quizTakerService.updateQuizTaker(this.quizTaker).subscribe(response => {
      this.quizTaker = response.data;
    });
  }
  startQuestion() {
    this.userScore = 0;
    this.userAnswer = 0;
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
    this.quizLocalation = QuizLocalation.SCORE;
    this.quizTakerService.getAllQuizTakerByQuizNumber(this.quiz.quizNumber).subscribe(response => {
      this.quizTakerList = response.data.sort((a, b) => b.score - a.score);
      let countDownRESULT = timer(0, 1000).subscribe(() => this.countdown--);
      setTimeout(() => {
        countDownRESULT.unsubscribe();
        this.quizLocalation = QuizLocalation.RESULT;
      }, 5000);
    })
  }
  getQuizTaker() {
    this.quizTakerService.getQuizTaker(this.quizTakerId).subscribe(response => {
      this.quizTaker = response.data;
    });
  }
  completedQuiz(){

  }
}
