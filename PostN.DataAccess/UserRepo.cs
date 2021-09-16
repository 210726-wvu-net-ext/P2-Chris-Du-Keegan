using Microsoft.EntityFrameworkCore;
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

        public Task<List<Domain.User>> GetUsers()
        {
            return Task.FromResult(_context.Users.Select(
                users => new Domain.User
                (
                    users.Id, 
                    users.FirstName, 
                    users.LastName, 
                    users.Email, 
                    users.Username, 
                    users.AboutMe, 
                    users.State, 
                    users.Country, 
                    users.Admin, 
                    users.PhoneNumber, 
                    users.DoB
                 )
            ).ToList());
        }
        public Task<Domain.User> GetUsersById(int id)
        {
            var returnedUser = _context.Users.Select(
                users => new Domain.User
                (
                    users.Id,
                    users.FirstName,
                    users.LastName,
                    users.Email,
                    users.Username,
                    users.AboutMe,
                    users.State,
                    users.Country,
                    users.Admin,
                    users.PhoneNumber,
                    users.DoB
                 )
            ).ToList();
            var USer = returnedUser.FirstOrDefault(user => user.Id == id);
            return Task.FromResult(USer);
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
        public async Task<Domain.User> AddAUser(Domain.User user)
        {
            if (UniqueUsername(user.Username) is true)
            {
                throw new Exception($"Username {user.Username} has been already used");
            }
            if (UniqueEmail(user.Email) is true)
            {
                throw new Exception($"Email {user.Email} has been already used");
            }

            await _context.Users.AddAsync(
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
            
            await _context.SaveChangesAsync();
            return user;
        }

        //Username should be unique
        public bool UniqueUsername(string username)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                return true;
            }
            return false;
        }
        //Email should be unique
        public bool UniqueEmail(string email)
        {
            if (_context.Users.Any(user => user.Email == email))
            {
                return false;
            }
            return true;
        }
        public List<Domain.Follower> GetFollowers()
        {
            return _context.Followers.Select(
                followers => new PostN.Domain.Follower(followers.Id, followers.UserId, followers.UserId2, followers.FriendRequest)
            ).ToList();

        }
        public async Task<bool> DeleteUserById(int id)
        {
            Entities.User userToDelete = await _context.Users
                .FirstOrDefaultAsync(user => user.Id == id);
            if(userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        //For the explore controller

        public Domain.User SearchUsersByName(string username)
        {
            try
            {
                Entities.User foundUser = _context.Users
               .FirstOrDefault(user => user.Username == username);
                return new Domain.User(foundUser.Id, foundUser.FirstName, foundUser.LastName, foundUser.Email, foundUser.Username, foundUser.AboutMe, foundUser.State, foundUser.Country, foundUser.Admin, foundUser.PhoneNumber, foundUser.DoB);
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }
        }
    }
}