using System;
using System.Drawing;
//https://stackoverflow.com/questions/2188134/what-variable-type-should-i-use-to-save-an-image/2188156
//This link has a possible implimentation of this namespace to include an image but idk how to make it work
namespace PostN.Domain
{
    public class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DoB { get; set; }

        // https://stackoverflow.com/questions/693389/what-data-type-should-i-use-for-an-image-in-my-domain-model
        //This link is what I used. Im not sure how the photo should be incorporated
        public byte[] Image { get; set; } 
    }
}
