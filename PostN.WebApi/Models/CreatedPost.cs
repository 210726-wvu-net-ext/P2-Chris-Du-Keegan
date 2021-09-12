using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostN.WebApi.Models
{
    public class CreatedPost
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Image { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Username { get; set; }
    }
}
