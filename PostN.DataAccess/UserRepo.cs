using PostN.DataAccess.Entities;
using PostN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostN.DataAccess.Entities;

namespace PostN.DataAccess
{
    public class UserRepo : IUserRepo
    {
        private readonly CMKWDTP2Context _context;
        public UserRepo(CMKWDTP2Context context)
        {
            _context = context;
        }

        public List<Users> GetUsers()
        {
            return _context.Users.Select(
                users => new PostN.Domain.Users(users.Id,users.FirstName, users.LastName, users.Password, users.Country, users.Email, users.PhoneNumber, users.DoB)
            ).ToList();
        }

        public List<Followers> GetFollowers()
        {
            return _context.Followers.Select(
                followers => new PostN.Domain.Followers(followers.Id, followers.UserId, followers.UserId2, followers.FriendRequest)
            ).ToList();
            //comment
            // comment
        }
    }
}
