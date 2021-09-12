using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostN.WebApi.Models
{
    public class CreatedComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int PostId { get; set; }
        public DateTime Created { get; set; }
        public string CommentBody { get; set; }
    }
}
