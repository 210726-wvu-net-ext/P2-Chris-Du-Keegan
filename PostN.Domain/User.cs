using System;
using System.Collections.Generic;

namespace PostN.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AboutMe { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Admin { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DoB { get; set; }
        public byte[] ProfilePic { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Follower> { get; set; }
        public List<Follower> FollowerUsers { get; set; }
        public List<Post> Posts { get; set; }
    }
}