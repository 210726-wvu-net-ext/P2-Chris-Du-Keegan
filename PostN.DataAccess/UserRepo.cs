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

        public Domain.User SearchUserById(int id)
        {
            Entities.User foundUser = _context.Users
                .FirstOrDefault(user => user.Id == id);
            return new Domain.User(foundUser.Id, foundUser.FirstName, foundUser.LastName, foundUser.Email, foundUser.Username, foundUser.AboutMe, foundUser.State, foundUser.Country, foundUser.Admin, foundUser.PhoneNumber, foundUser.DoB);
        }
        public void UpdateUser(string otherFirstName, string otherLastName, string otherEmail, string otherPhoneNumber, string otherAboutMe, int id)
        {
            Entities.User olduser = _context.Users.First(user => user.Id == id);
                if (otherFirstName == null) otherFirstName = olduser.FirstName;  
            olduser.FirstName = otherFirstName;
                if (otherLastName == null) otherLastName = olduser.LastName;
            olduser.LastName = otherLastName;
                if (otherEmail == null) otherEmail = olduser.Email;
            olduser.Email = otherEmail;
                if (otherPhoneNumber == null) otherPhoneNumber = olduser.PhoneNumber;
            olduser.PhoneNumber = otherPhoneNumber;
                if (otherAboutMe == null) otherAboutMe = olduser.AboutMe;
            olduser.AboutMe = otherAboutMe;
                
            _context.SaveChanges();
            
        }
        public Domain.User AddAUser(Domain.User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                throw new Exception($"Username {user.Username} has been already used");
            }
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception($"Email {user.Email} has been already used");
            }
            _context.Users.Add(
                new Entities.User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.Username,
                    Password = user.Password,
                    AboutMe = user.AboutMe,
                    State = user.State,
                    Country = user.Country,
                    PhoneNumber = user.PhoneNumber,
                    DoB = user.DoB,
                }
            );
            _context.SaveChanges();
            return user;
        }
        public List<Domain.Follower> GetFollowers()
        {
            return _context.Followers.Select(
                followers => new PostN.Domain.Follower(followers.Id, followers.UserId, followers.UserId2, followers.FriendRequest)
            ).ToList();

        }
        public void DeleteUser(int id)
        {
            Entities.User foundUser = _context.Users
                .FirstOrDefault(user => user.Id == id);
            _context.Users.Remove(foundUser);
            _context.SaveChanges();
        }

        public DataAccess.Entities.User SearchUsersByName(string username)
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