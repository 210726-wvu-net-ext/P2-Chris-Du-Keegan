using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PostN.Domain
{
    public interface IPostRepo
    {
<<<<<<< HEAD
        List<Post> GetPost();
=======
        List<Post> GetAllPosts();
        Post GetPostById(int id);

        Post CreatePost(Post post);

        Post UpdatePostById(int id, Post post);

        Post DeletePostById(int id, Post post);

        Post CreateCommentByPostId(int postId, Comment comment);

        Post UpdateCommentById(int commentId, Comment comment);

        Post DeleteCommentById(int commentId, Comment comment);
>>>>>>> Develop
    }
}
