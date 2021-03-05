import { ChangeDetectorRef, Component, ElementRef, HostListener, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
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

  public questions: IQuestion[];

  constructor(private quizService: QuizService,
    private renderer: Renderer2,
    private cdref: ChangeDetectorRef) { }

  ngOnInit() {
      this.GetQuestions();
  }

  ngAfterViewInit() {
    this.questionComponents.changes.subscribe(() => {
      this.onQuestion(true);
      this.cdref.detectChanges();
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
    this.userSelections.push(info);
    this.onQuestion(true);
    this.tryToCheckQuiz();
  }

  public expiredTimer(questionId: number) {
    const emptySelection: IUserSelection = {
      questionId: questionId,
      answerId: -1
    };
    this.onQuestion(false);
    this.userSelections.push(emptySelection);
    if (this.userSelections.length == this.questions.length) {
      this.tryToCheckQuiz();
    } else {
      this.onQuestion(true);
    }
  }

  private tryToCheckQuiz() {
    if (this.userSelections.length == this.questions.length) {
      const userId = localStorage.getItem('userId');
      const body: IQuizCheck = {
        id: +localStorage.getItem('quizId'),
        userId: userId,
        selections: this.userSelections
      };

      this.quizService.checkQuiz(body).subscribe((data: IQuizResult) => {
        this.chart.doughnutChartData = [ data.unselected, data.wrong, data.correct];
        this.renderer.removeStyle(this.chartDiv.nativeElement, 'display');
      });
    }
  }

  private onQuestion(clickable: boolean) {
    this.questionComponents.toArray().forEach((q, i) => {
      if (i == this.userSelections.length) {
        q.showTimer = true;
        q.manipulateAllAnswers(clickable);
      }
    });
  }

  ngOnDestroy() {
    this.beforeUnload();
  }

  @HostListener('window:beforeunload')
  private beforeUnload() {
    // if (this.userSelections.length < 5) {
    //   const result = confirm("Want to leave?");
    //   if (!result) {
    //     return null;
    //   }
    // }
  }
}
