import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IAnswer } from 'src/app/models/quiz/answer';

@Component({
  selector: 'app-answer',
  templateUrl: './answer.component.html',
  styleUrls: ['./answer.component.css']
})
export class AnswerComponent {
  @Output() answerClicked: EventEmitter<number> = new EventEmitter<number>();
  @Input() answer: IAnswer;
  
  private clicked = false;
  public clickable: boolean = true;

  public announce(evt) {
    if (this.clickable && evt.checked) {
      this.answerClicked.emit(this.answer.id);
      this.clicked = true;
    } else if (!this.clicked) {
      evt.checked = false;
    }
  }
}
