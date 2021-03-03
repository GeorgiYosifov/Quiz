import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { IQuestion } from 'src/app/models/quiz/question';
import { IUserSelection } from 'src/app/models/quiz/user-selection';
import { IQuizCheck } from 'src/app/models/quiz/quiz-check';
import { QuizService } from 'src/app/services/quiz.service';
import { IQuizResult } from 'src/app/models/quiz/quiz-result';
import { ChartComponent } from '../chart/chart.component';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent {

  @ViewChild(ChartComponent) private chart: ChartComponent;
  @ViewChild('chartDiv') private chartDiv: ElementRef;

  private userSelections: IUserSelection[] = [];
  public questions: IQuestion[];

  constructor(private quizService: QuizService,
    private renderer: Renderer2) { }

  ngOnInit() {
    this.quizService.createQuiz().subscribe((data: number) => {
      localStorage.setItem('quizId', data.toString());
      this.quizService.getQuiz(data).subscribe(data => {
        this.questions = data['questions'];
      });
    });    
  }

  public getSelection(info: IUserSelection) {
    this.userSelections.push(info);
    if (this.userSelections.length == this.questions.length) {
      const body: IQuizCheck = {
        id: +localStorage.getItem('quizId'),
        selections: this.userSelections
      };

      this.quizService.checkQuiz(body).subscribe((data: IQuizResult) => {
        this.chart.doughnutChartData = [data.wrong, data.correct];
        this.renderer.removeStyle(this.chartDiv.nativeElement, 'display');
      });
    }
  }
}
