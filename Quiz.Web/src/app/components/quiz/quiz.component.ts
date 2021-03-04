import { Component, ElementRef, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
import { IQuestion } from 'src/app/models/quiz/question';
import { IUserSelection } from 'src/app/models/quiz/user-selection';
import { IQuizCheck } from 'src/app/models/quiz/quiz-check';
import { QuizService } from 'src/app/services/quiz.service';
import { IQuizResult } from 'src/app/models/quiz/quiz-result';
import { ChartComponent } from '../chart/chart.component';
import { QuestionComponent } from '../question/question.component';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent {

  @ViewChildren(QuestionComponent) private questionComponents: QueryList<QuestionComponent>;
  @ViewChild(ChartComponent) private chart: ChartComponent;
  @ViewChild('chartDiv') private chartDiv: ElementRef;

  private userSelections: IUserSelection[] = [];
  private counter: number = 0;

  public questions: IQuestion[];

  constructor(private quizService: QuizService,
    private renderer: Renderer2) { }

  ngOnInit() {
      this.GetQuestions();
  }

  ngAfterViewInit() {
    this.questionComponents.changes.subscribe(() => {
      this.onQuestion();
    });
  }

  public GetQuestions() {
    this.quizService.createQuiz().subscribe((data: number) => {
      localStorage.setItem('quizId', data.toString());
      this.quizService.getQuiz(data).subscribe(data => {
        this.questions = data['questions'];
      });
    });  
  }

  public getSelection(info: IUserSelection) {
    this.counter++;
    this.onQuestion();
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

  private onQuestion() {
    this.questionComponents.toArray().forEach((q, i) => {
      if (i == this.counter) {
        q.showTimer = true;
        q.manipulateAllAnswers(true);
      }
    });
  }
}
