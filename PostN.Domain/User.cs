using System;
using System.Collections.Generic;

namespace PostN.Domain
{
    public class User
    {
        public User() { }

        public User(int id, string firstName, string lastName, string aboutMe)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AboutMe = aboutMe;
        }

        public User(int id, string firstName, string lastname, string email, string username, string aboutMe, string state, string country, int admin, string phonenumber, DateTime dob)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Email = email;
            this.Username = username;
            this.AboutMe = aboutMe;
            this.State = state;
            this.Country = country;
            this.Admin = admin;
            this.PhoneNumber = phonenumber;
            this.DoB = dob;
        }

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
        public List<Follower> Friends { get; set; }
        public List<Post> Posts { get; set; }
    }
}