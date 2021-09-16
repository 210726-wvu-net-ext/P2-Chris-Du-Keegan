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
        void UpdateUser(string otherFirstName, string otherLastName, string otherEmail, string otherPhoneNumber, string otherAboutMe, int id);
        User SearchUserById(int id);
        Task<User> AddAUser(User user);
        Task<bool> DeleteUserById(int id);
        List<Follower> GetFollowers();
        User SearchUsersByName(string username);
        bool UniqueUsername(string username);
        bool UniqueEmail(string email);

    }
}
