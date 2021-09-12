using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.Domain
{
    public class Post
    {
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
