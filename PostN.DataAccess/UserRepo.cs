using PostN.DataAccess.Entities;
using PostN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.DataAccess
{
    public class UserRepo : IUserRepo
    {
        private readonly CMKWDTP2Context _context;
        public UserRepo(CMKWDTP2Context context)
        {
            _context = context;
        }
        public List<PostN.Domain.User> GetUsers()
        {
            return _context.Users.Select(
                user => new PostN.Domain.User(user.Id, user.FirstName, user.LastName, user.AboutMe)
            ).ToList();
        }
    }
}
