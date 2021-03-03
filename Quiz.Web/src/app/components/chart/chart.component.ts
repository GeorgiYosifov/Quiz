import { Component } from '@angular/core';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent {
  public doughnutChartLabels: string[] = ['Wrong', 'Correct'];
  public doughnutChartData = [];
  public chartColors = [
    { 
      backgroundColor: ['#d13537', '#32CD32']
    }
  ];
  public doughnutChartType: string = 'doughnut';
}
