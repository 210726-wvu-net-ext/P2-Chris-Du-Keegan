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
        Task<User> GetUsersById(int id);
        Task<User> UpdateUser(int id, string otherFirstName, string otherLastName, string otherEmail, string otherPhoneNumber, string otherAboutMe);
        User SearchUserById(int id);
        Task<User> AddAUser(User user);
        Task<bool> DeleteUserById(int id);
        User SearchUsersByName(string username);
        List<Follower> GetFollowers();
        Task<Follower> AddAFollower(Follower follower);
        Task<bool> DeleteFollower(int id);
        bool UniqueUsername(string username);
        bool UniqueEmail(string email);

    }
}
