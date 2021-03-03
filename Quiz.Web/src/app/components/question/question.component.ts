import { Component, EventEmitter, Input, Output, QueryList, ViewChildren } from '@angular/core';
import { IQuestion } from 'src/app/models/quiz/question';
import { IUserSelection } from 'src/app/models/quiz/user-selection';
import { AnswerComponent } from '../answer/answer.component';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent {

  @ViewChildren(AnswerComponent) private answerComponents: QueryList<AnswerComponent>;
  @Input() question: IQuestion;
  @Output() emitSelection: EventEmitter<IUserSelection> = new EventEmitter<IUserSelection>();
  
  constructor() { }

  public announceOtherAnswers(id: number) {
    const answerId: number = id;
    const questionId: number = this.question.id;
    this.emitSelection.emit({ questionId, answerId });
    this.answerComponents.forEach(a => {
      a.clickable = false;
    })
  }
}
