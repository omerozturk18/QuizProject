import { UserService } from './../../../services/user.service';
import { AuthService } from 'src/app/services/auth.service';
import { Status } from './../../../models/Status';
import { ToastrService } from 'ngx-toastr';
import { QuizService } from 'src/app/services/quiz.service';
import { Quiz } from './../../../models/Quiz';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { QuizModelView } from 'src/app/models/QuizModelView';

@Component({
  selector: 'app-quizList',
  templateUrl: './quizList.component.html',
  styleUrls: ['./quizList.component.css']
})
export class QuizListComponent implements OnInit {
  quizList:QuizModelView[]=[];
  quizStatus=Status;
  constructor(private router:Router,
    private quizService:QuizService,
    private authService:AuthService,
    private toastrService:ToastrService) { }

  ngOnInit() {
   this.getQuizzes();
  }

  getQuizzes(){
   let user= this.authService.getCurrentUser();
   console.log(user);
    this.quizService.getUserQuizzes(user.UserId).subscribe(response=>{
      this.quizList= response.data;
    });
  }
  addQuiz(){
    this.router.navigateByUrl("user/quizWizard/0")
  }
  editQuiz(quiz:QuizModelView){
    this.router.navigateByUrl("user/quizWizard/"+quiz.id)
  }
  deleteQuiz(quiz:QuizModelView){
    this.quizService.deleteQuiz(quiz).subscribe(response=>{
      this.toastrService.success(response.message);
      this.getQuizzes();
    })
  }
  activatedQuiz(quiz:QuizModelView){
    this.quizService.activatedQuiz(quiz).subscribe(response=>{
      this.toastrService.success(response.message);
      this.router.navigateByUrl("user/preparation/"+quiz.id)
    })
  }
  questionList(quiz:QuizModelView){
    this.router.navigateByUrl("user/questionList/"+quiz.id)
  }
  quizPreparation(quiz:QuizModelView){
    localStorage.setItem("QUIZNUMBER",quiz.quizNumber)
    this.router.navigateByUrl("user/quizPreparation/"+quiz.quizNumber)
  }
}
