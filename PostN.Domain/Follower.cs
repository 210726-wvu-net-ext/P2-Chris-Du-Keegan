namespace PostN.Domain
{
    public class Follower
    {
        public Follower(int id, int userId2, string username, int friendrequest)
        {
            Id = id;
            UserId2 = userId2;
            FriendUsername = username;
            FriendRequest = friendrequest;
        }

        public Follower(int id, int userid, int userid2, int friedrequest)
        {
            this.Id = id;
            this.UserId = userid;
            this.UserId2 = userid2;
            this.FriendRequest = friedrequest;
        }
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Username { get; set; }
        public int UserId2 { get; set; }

        public string FriendUsername { get; set; }
        public int FriendRequest { get; set; }
    }
}