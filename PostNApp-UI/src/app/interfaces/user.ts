import { Post } from "./post";
import { Comment } from "./comment";

export interface User {
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    username: string,
    password: string,
    aboutMe: string,
    state: string,
    country: string,
    admin: number,
    phoneNumber: string,
    dob: Date,
    Comments: Comment[],
    Posts: Post[],
    Follows: []
}