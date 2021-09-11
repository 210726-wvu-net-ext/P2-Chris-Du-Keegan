using System;

namespace PostN.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int PostId { get; set; }
        public DateTime Created { get; set; }
        public string CommentBody { get; set; }
    }
}