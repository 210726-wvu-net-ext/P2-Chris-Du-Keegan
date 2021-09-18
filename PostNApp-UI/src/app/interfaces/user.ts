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
    Comments: [],
    Posts: [],
    Follows: []
}