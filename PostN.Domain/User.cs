using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string AboutMe { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        
        public string Profilepic { get; set; }
    }
}
