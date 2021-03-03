import { IQuestion } from "./question";

export interface IQuiz {
    id: number;
    userId: string;
    questions: IQuestion[];
}