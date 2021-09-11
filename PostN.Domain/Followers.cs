using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.Domain
{
    public class Followers
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int UserID2 { get; set; }
        public int FriendRequest { get; set; }
    }
}
