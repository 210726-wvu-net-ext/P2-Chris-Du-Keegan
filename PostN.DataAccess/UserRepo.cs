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

        public List<Domain.User> GetUsers()
        {
            return _context.Users.Select(
                users => new Domain.User(users.Id, users.FirstName, users.LastName, users.Email, users.Username, users.AboutMe, users.State, users.Country, users.Admin, users.PhoneNumber, users.DoB)
            ).ToList();
        }

        public List<Domain.Follower> GetFollowers()
        {
            return _context.Followers.Select(
                followers => new PostN.Domain.Follower(followers.Id, followers.UserId, followers.UserId2, followers.FriendRequest)
            ).ToList();

        }

        public DataAccess.Entities.User SearchUsers(string username)
        {
            try
            {
                 var user = _context.Users.Single(u => u.Username.Equals(username));
                return user;
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }
        }
    }
}