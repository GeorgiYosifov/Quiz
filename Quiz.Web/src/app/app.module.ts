import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { QuizComponent } from './components/quiz/quiz.component';
import { QuestionComponent } from './components/question/question.component';
import { AnswerComponent } from './components/answer/answer.component';
import { CategoryComponent } from './components/category/category.component';
import { HistoryComponent } from './components/history/history.component';
import { IdentityService } from './services/identity.service';
import { QuizService } from './services/quiz.service';
import { NavigationComponent } from './components/navigation/navigation.component';
import { ChartsModule } from 'ng2-charts';
import { ChartComponent } from './components/chart/chart.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    QuizComponent,
    QuestionComponent,
    AnswerComponent,
    CategoryComponent,
    HistoryComponent,
    NavigationComponent,
    ChartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    ChartsModule
  ],
  providers: [
    IdentityService,
    QuizService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
