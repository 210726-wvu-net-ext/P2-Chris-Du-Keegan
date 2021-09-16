using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PostN.Domain
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, string otherFirstName, string otherLastName, string otherEmail, string otherPhoneNumber, string otherAboutMe);
        Task<User> SearchUserById(int id);
        Task<User> AddAUser(User user);
        Task<bool> DeleteUserById(int id);
        List<Follower> GetFollowers();
        User SearchUsersByName(string username);
        bool UniqueUsername(string username);
        bool UniqueEmail(string email);

    }
}
