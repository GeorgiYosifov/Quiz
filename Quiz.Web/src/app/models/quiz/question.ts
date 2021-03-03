import { IAnswer } from "./answer";

export interface IQuestion {
    id: number;
    content: string;
    categoryId: number;
    answers: IAnswer[];
}