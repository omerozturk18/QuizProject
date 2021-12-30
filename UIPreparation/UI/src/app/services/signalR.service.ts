import { ToastrService } from 'ngx-toastr';
import { Injectable } from '@angular/core';

import {
  HubConnection,
  HubConnectionBuilder,
  HubConnectionState,
  LogLevel
} from '@microsoft/signalr';
import { BehaviorSubject, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { QuizTaker } from '../models/QuizTaker';
import { Quiz } from '../models/Quiz';

@Injectable({ providedIn: 'root' })
export class SignalRService {
  changeQuizTaker = new Subject<QuizTaker>();
  startedQuiz = new Subject<Quiz>();
  changeQuestion = new Subject<Quiz>();
  completedQuiz = new Subject<Quiz>();

  connectionEstablished$ = new BehaviorSubject<boolean>(false);

  private hubConnection: HubConnection;

  constructor(private toastrService:ToastrService) {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  // sendChatMessage(message: ChatMessage) {
  //   this.hubConnection.invoke('SendMessage', message);
  // }

  private createConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(environment.basePath + 'quizSignal')
      .withAutomaticReconnect()
      .configureLogging(LogLevel.Information)
      .build();
  }

  private startConnection() {
    if (this.hubConnection.state === HubConnectionState.Connected) {
      return;
    }

    this.hubConnection.start().then(
      () => {
        console.log('Hub connection started!');
        this.connectionEstablished$.next(true);
      },
      error => console.error(error)
    );
  }

  private registerOnServerEvents(): void {

    this.hubConnection.on('Send', (data: any) => {
      console.log('data', data);
   //   this.messageReceived$.next(data);
    });
    this.hubConnection.on('AddQuizTaker'+localStorage.getItem("QUIZNUMBER"), (data: any) => {
      this.changeQuizTaker.next(data);
      this.toastrService.info(data.userName+" Katıldı")
    });
    this.hubConnection.on('StartedQuiz'+localStorage.getItem("QUIZNUMBER"), (data: any) => {
      this.startedQuiz.next(data);
    });
    this.hubConnection.on('ChangeQuestion'+localStorage.getItem("QUIZNUMBER"), (data: any) => {
      this.changeQuestion.next(data);
    });
    this.hubConnection.on('CompletedQuiz'+localStorage.getItem("QUIZNUMBER"), (data: any) => {
      this.completedQuiz.next(data);
    });
  }
}
