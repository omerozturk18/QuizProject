import { UserPlayGameComponent } from './components/user/userPlayGame/userPlayGame.component';
import { QuizPreparationCutomerComponent } from './components/quizPreparationCutomer/quizPreparationCutomer.component';
import { QuizWizardComponent } from './components/quiz/quizWizard/quizWizard.component';
import { UserAppComponent } from './components/user/userApp/userApp.component';
import { AdminAppComponent } from './components/admin/adminApp/adminApp.component';
import { DashboardComponent } from './components/user/dashboard/dashboard.component';
import { AuthorizationComponent } from './components/admin/authorization/authorization.component';
import { QuestionListComponent } from './components/question/questionList/questionList.component';
import { QuestionUpdateComponent } from './components/question/questionUpdate/questionUpdate.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JoinGameComponent } from './components/joinGame/joinGame.component';
import { LoginComponent } from './components/login/login.component';
import { PlayGameComponent } from './components/playGame/playGame.component';
import { QuizPreparationComponent } from './components/user/quizPreparation/quizPreparation.component';
import { QuizUpdateComponent } from './components/quiz/quizUpdate/quizUpdate.component';
import { LoginGuard } from './guards/login.guard';
import { QuizListComponent } from './components/quiz/quizList/quizList.component';
import { AdminGuard } from './guards/admin.guard';
import { AdminDashboardPageComponent } from './components/admin/admin-dashboard-page/admin-dashboard-page.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'joinGame',
    pathMatch: 'full',
  },
  { path: 'joinGame', component: JoinGameComponent },
  { path: 'playGame/:quizNumber', component: PlayGameComponent },
  { path: 'login', component: LoginComponent },

  { path: 'quizPreparation/:quizNumber', component: QuizPreparationCutomerComponent },

  {
    path: 'admin',
    component: AdminAppComponent,
    canActivate: [ AdminGuard],
    children: [
      {
        path: 'authorization',
        component: AuthorizationComponent,
      },
      {
        path: 'dashboard',
        component: AdminDashboardPageComponent,
      },
    ],
  },
  {
    path: 'user',
    component: UserAppComponent,
    canActivate: [LoginGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'playGame/:quizNumber', component: UserPlayGameComponent },
      { path: 'quizWizard/:quizId', component: QuizWizardComponent },
      { path: 'quizList', component: QuizListComponent },
      { path: 'updateQuiz/:quizId', component: QuizUpdateComponent },
      { path: 'questionList/:quizId', component: QuestionListComponent },
      { path: 'updateQuestion/:questionId/:quizId', component: QuestionUpdateComponent },
      { path: 'quizPreparation/:quizNumber', component: QuizPreparationComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
