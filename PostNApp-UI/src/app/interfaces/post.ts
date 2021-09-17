export interface Post {
    id: number,
    userId: number,
    image: string,
    created: string,
    title: string,
    body: string,
    username: string,
    comments: []
}