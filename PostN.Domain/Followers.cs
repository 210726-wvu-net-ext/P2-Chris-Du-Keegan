using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.Domain
{
    public class Followers
    {
        public Followers(int id, int userid, int userid2, int friedrequest)
        {
            this.ID = id;
            this.UserID = userid;
            this.UserID2 = userid2;
            this.FriendRequest = friedrequest;
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public int UserID2 { get; set; }
        public int FriendRequest { get; set; }
    }
}
