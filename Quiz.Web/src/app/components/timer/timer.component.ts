import { Component, ElementRef, Renderer2, ViewChild } from '@angular/core';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.css']
})
export class TimerComponent {
  
  @ViewChild('timerDiv') private timerDiv: ElementRef;

  private stackTimeout: { value: NodeJS.Timeout } = { value: undefined };

  constructor(private renderer: Renderer2) { }

  ngAfterViewInit() {
    this.startTimer(this.stackTimeout);
  }

  public startTimer(stackTimeout: { value: NodeJS.Timeout }) {
    const interval: number = 1000; // ms
    let expected: number = Date.now() + interval;
    const endTime: number = Date.now() + 45 * 1000;

    const renderer: Renderer2 = this.renderer;
    const getTimeToString = this.getTimeToString;
    const stopTimer = this.stopTimer;
    const timerDiv = this.timerDiv;

    stackTimeout.value = setTimeout(step, interval);

    function step() {
      if (expected > endTime) {
        console.log('stop');
        return stopTimer(stackTimeout);
      }

      const dt = Date.now() - expected;
      const remainingTime = endTime - expected; // ms
      renderer.setProperty(timerDiv.nativeElement, 'innerHTML', getTimeToString(remainingTime));
      
      expected += interval;
      stackTimeout.value = setTimeout(step, Math.max(0, interval - dt));
    }
  }

  public stopTimer(stackTimeout: { value: NodeJS.Timeout }) {
    clearTimeout(stackTimeout.value);
    stackTimeout.value = undefined;
  }

  private getTimeToString(time: number): string {
    const minutes = Math.floor(time / (60 * 1000));
    const seconds = (Math.round((time / 1000) % 60)).toString();
    return `${minutes}:${seconds.length > 1 ? seconds : '0' + seconds}`;
  }
}
