using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.Domain
{
    public class Post
    {
<<<<<<< HEAD
        public Post(int id, int userId, byte[] image, DateTime created, string title, string body)
        {
            this.Id = id;
            this.UserId = userId;
            this.Image = image;
            this.Created = created;
            this.Title = title;
            this.Body = body;
        }

=======
        public Post() { }
>>>>>>> Develop
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Image { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public string Username { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
