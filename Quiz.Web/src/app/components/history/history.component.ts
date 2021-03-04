import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { ICategory } from 'src/app/models/quiz/category';
import { IHistoryAnswer } from 'src/app/models/quiz/history-answer';
import { QuizService } from 'src/app/services/quiz.service';
import { ChartComponent } from '../chart/chart.component';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent {

  @ViewChild(ChartComponent) private chart: ChartComponent;
  @ViewChild('chartDiv') private chartDiv: ElementRef;

  public allAnswers: IHistoryAnswer[];
  public categories: ICategory[];

  constructor(private quizService: QuizService,
    private renderer: Renderer2) { }

  ngOnInit() {
    this.quizService.getHistory().subscribe((data: IHistoryAnswer[]) => {
      if (data) {
        this.allAnswers = data;
        this.setChartData(this.allAnswers);
        this.renderer.removeStyle(this.chartDiv.nativeElement, 'display');
      }
    });

    this.quizService.getCategories().subscribe((data: ICategory[]) => {
      this.categories = data;
    });
  }

  public changeChartData(categoryId: number) {
    if (this.allAnswers) {
      this.setChartData(this.allAnswers.filter(a => a.categoryId == categoryId));
    }
  }

  private setChartData(answers: IHistoryAnswer[]) {
    let wrong: number = 0;
    let correct: number = 0;
    answers.forEach(a => {
      if (a.isCorrect) {
        correct++;
      } else {
        wrong++;
      }
    });
    this.chart.doughnutChartData = [ wrong, correct ];
  }
}
