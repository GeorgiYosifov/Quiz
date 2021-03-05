import { Component } from '@angular/core';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent {
  public doughnutChartLabels: string[] = ['Unselected', 'Wrong', 'Correct'];
  public doughnutChartData: number[] = [];
  public chartColors = [
    { 
      backgroundColor: ['#A9A9A9', '#d13537', '#32CD32']
    }
  ];
  public doughnutChartType: string = 'doughnut';
}
