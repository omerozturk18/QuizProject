import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuizTaker } from 'src/app/models/QuizTaker';
import { QuizService } from 'src/app/services/quiz.service';
import { QuizTakerService } from 'src/app/services/quizTaker.service';
import { SignalRService } from 'src/app/services/signalR.service';

@Component({
  selector: 'app-quizPreparation',
  templateUrl: './quizPreparation.component.html',
  styleUrls: ['./quizPreparation.component.css']
})
export class QuizPreparationComponent implements OnInit {
  quizNumber: string;
  quizTakerList: QuizTaker[] = [];
  errorMessage = '';
  constructor(
    private activatedRoute: ActivatedRoute,
    private signalRService: SignalRService,
    private quizTakerService: QuizTakerService,
    private quizService: QuizService,
    private router:Router
  ) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(param => {
      this.quizNumber = param["quizNumber"];
      this.getQuizTakerData();
      this.signalRService.changeQuizTaker.subscribe(() => this.getQuizTakerData());
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
  startedQuiz(){
    this.quizService.isThereQuiz(this.quizNumber).subscribe(response=>{
      this.quizService.startedQuiz(response.data).subscribe(startedQuizResponse=>{
         this.router.navigateByUrl("user/playGame/"+this.quizNumber);
      })
    });
  }
}
