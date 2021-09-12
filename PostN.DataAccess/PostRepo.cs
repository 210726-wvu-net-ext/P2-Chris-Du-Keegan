using PostN.DataAccess.Entities;
using PostN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.DataAccess
{
    public class PostRepo : IPostRepo
    {
        private readonly CMKWDTP2Context _context;
        public PostRepo(CMKWDTP2Context context)
        {
            _context = context;
        }

        public List<Domain.Post> GetPost()
        {
            return _context.Posts.Select(
                users => new Domain.Post(users.Id, users.UserId, users.Image, users.Created, users.Title, users.Body)
            ).ToList();
        }
    }
}
