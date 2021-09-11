namespace PostN.Domain
{
    public class Follower
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Username { get; set; }
        public int UserId2 { get; set; }

        public string FriendUsername { get; set; }
        public int FriendRequest { get; set; }
    }
}