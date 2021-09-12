using PostN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.DataAccess
{
    public class PostRepo : IPostRepo
    {
        public Post CreateCommentByPostId(int postId, Comment comment)
        {
            throw new NotImplementedException();
        }

        public Post CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Post DeleteCommentById(int commentId, Comment comment)
        {
            throw new NotImplementedException();
        }

        public Post DeletePostById(int id, Post post)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Post UpdateCommentById(int commentId, Comment comment)
        {
            throw new NotImplementedException();
        }

        public Post UpdatePostById(int id, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
