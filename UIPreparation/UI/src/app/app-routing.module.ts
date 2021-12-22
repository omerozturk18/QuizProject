import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JoinGameComponent } from './components/joinGame/joinGame.component';
import { PlayGameComponent } from './components/playGame/playGame.component';
import { QuizPreparationComponent } from './components/quizPreparation/quizPreparation.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'joinGame',
    pathMatch: 'full',
  },
  { path: 'joinGame', component: JoinGameComponent },
  { path: 'quizPreparation', component: QuizPreparationComponent },
  { path: 'playGame', component: PlayGameComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
