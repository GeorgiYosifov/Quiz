import { IUserSelection } from "./user-selection";

export interface IQuizCheck {
    id: number;
    userId: string;
    selections: IUserSelection[];
}