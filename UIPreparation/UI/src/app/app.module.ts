import { AuthorizationComponent } from './components/admin/authorization/authorization.component';
import { UserPlayGameComponent } from './components/user/userPlayGame/userPlayGame.component';
import { QuizPreparationCutomerComponent } from './components/quizPreparationCutomer/quizPreparationCutomer.component';
import { LoginGuard } from './guards/login.guard';
import { AdminGuard } from './guards/admin.guard';
import { QuizWizardComponent } from './components/quiz/quizWizard/quizWizard.component';
import { QuestionUpdateComponent } from './components/question/questionUpdate/questionUpdate.component';
import { QuestionListComponent } from './components/question/questionList/questionList.component';
import { UserAppComponent } from './components/user/userApp/userApp.component';
import { AdminAppComponent } from './components/admin/adminApp/adminApp.component';
import { AdminDashboardPageComponent } from './components/admin/admin-dashboard-page/admin-dashboard-page.component';
import { QuizUpdateComponent } from './components/quiz/quizUpdate/quizUpdate.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from "@angular/forms"
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VatAddedPipe } from './pipes/vat-added.pipe';

import { ToastrModule } from "ngx-toastr";

import { LoginComponent } from './components/login/login.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { PlayGameComponent } from './components/playGame/playGame.component';
import { QuizPreparationComponent } from './components/user/quizPreparation/quizPreparation.component';
import { JoinGameComponent } from './components/joinGame/joinGame.component';
import { DashboardComponent } from './components/user/dashboard/dashboard.component';
import { NaviComponent } from './components/navi/navi.component';
import { HttpErrorInterceptor } from './interceptors/http-error.interceptor';
import { QuizListComponent } from './components/quiz/quizList/quizList.component';
import { NgWizardModule, NgWizardConfig, THEME } from 'ng-wizard';
import { NgbModal, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { FormatTimePipe } from './pipes/formatTime.pipe';

const ngWizardConfig: NgWizardConfig = {
  theme: THEME.default
};
@NgModule({
  declarations: [
    AppComponent,
    NaviComponent,
    VatAddedPipe,
    LoginComponent,
    DashboardComponent,
    JoinGameComponent,
    QuizPreparationComponent,
    PlayGameComponent,
    QuizUpdateComponent,
    QuizListComponent,
    AdminDashboardPageComponent,
    AdminAppComponent,
    UserAppComponent,
    QuestionListComponent,
    QuestionUpdateComponent,
    QuizWizardComponent,
    QuizPreparationCutomerComponent,
     FormatTimePipe,
      UserPlayGameComponent,
      AuthorizationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: "toast-bottom-right"
    }),
    NgWizardModule.forRoot(ngWizardConfig),
    NgbModalModule
  ],
  providers: [
    AdminGuard,
    LoginGuard,
    NgbModal,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
