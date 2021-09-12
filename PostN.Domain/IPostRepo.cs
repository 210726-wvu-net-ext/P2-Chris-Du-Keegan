using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PostN.Domain
{
    public interface IPostRepo
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);

        Task<Post> CreatePost(Post post);

        Task<Post> UpdatePostById(int id, Post post);

        Post DeletePostById(int id, Post post);

        Task<Comment> CreateCommentByPostId(int postId, Comment comment);

        Task<Post> UpdateCommentById(int commentId, Comment comment);

        Post DeleteCommentById(int commentId, Comment comment);
    }
}
