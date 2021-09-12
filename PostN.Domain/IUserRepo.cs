using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.Domain
{
    public interface IUserRepo
    {
        List<User> GetUsers();
        void UpdateUser(string otherFirstName, string otherLastName, string otherEmail, string otherPhoneNumber, string otherAboutMe, int id);
        User AddAUser(User user);
        void DeleteUser(int id);
        List<Follower> GetFollowers();
    }
}
