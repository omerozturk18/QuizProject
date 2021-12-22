import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { JoinGameComponent } from './components/joinGame/joinGame.component';
import { QuizPreparationComponent } from './components/quizPreparation/quizPreparation.component';
import { PlayGameComponent } from './components/playGame/playGame.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    JoinGameComponent,
    QuizPreparationComponent,
    PlayGameComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
