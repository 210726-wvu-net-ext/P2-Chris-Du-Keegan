using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostN.Domain;
using PostN.WebApi.Models;

namespace PostN.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;

        public PostController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        // GET: api/post - we are getting all posts
        [HttpGet]
        public IActionResult Get()
        {
            List<Post> Post = _postRepo.GetAllPosts();
            return Ok(Post);
        }

        // GET api/post/5 -- gets a specific post to display
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            if (_postRepo.GetPostById(id) is Post singlePost)
            {
                return Ok(singlePost);
            }
            // need to return comments as well
            return NotFound();
        }

        // POST api/post - creates new post
        [HttpPost]
        public IActionResult Post([FromBody] CreatedPost viewPost)
        {
            //need to check if user is logged in. need user's ID
            //return the new post information - route them to that specific post
            if(viewPost != null)
            {
                var post = new Post
                {
                    UserId = viewPost.UserId,
                    Image = viewPost.Image,
                    Created = viewPost.Created,
                    Title = viewPost.Title,
                    Body = viewPost.Body,
                    Username = viewPost.Username
                };
                try
                {
                    var newPost = _postRepo.CreatePost(post);
                    return Ok(newPost);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
            return NotFound();
        }

        // PUT api/post/5 // update post body
        [HttpPut("{id}")]
        public ActionResult<Post> Put(int id, [FromBody] Post post)
        {
            if (_postRepo.GetPostById(id) is Post oldPost)
            {
                oldPost.Title = post.Title;
                oldPost.Image = post.Image;
                oldPost.Body = post.Body;

                Post updatedPost = _postRepo.UpdatePostById(id, oldPost);
                return Ok(updatedPost);
            }
            return NotFound();
        }

        // DELETE api/post/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_postRepo.GetPostById(id) is Post post)
            {
                _postRepo.DeletePostById(id, post);
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{postId}/comment")]
        public ActionResult<Post> Post(int postId, [FromBody] CreatedComment comment)
        {
            if(_postRepo.GetPostById(postId) is Post post)
            {
                var newComment = new Comment
                {
                    UserId = comment.UserId,
                    Username = comment.Username,
                    PostId = postId,
                    Created = comment.Created
                };
                post = _postRepo.CreateCommentByPostId(postId, newComment);
                return Ok(post);
            }
            return NotFound();
        }

        [HttpPut("{postId}/comment/{commentId}")]
        public ActionResult<Post> Put(int postId, int commentId, [FromBody] Comment comment)
        {
            // find post ID, then comment ID, then update comment
            if (_postRepo.GetPostById(postId) is Post post)
            {
                Post postUpdatedComment = _postRepo.UpdateCommentById(commentId, comment);
                return Ok(postUpdatedComment);
            }
            return NotFound();
        }
        [HttpDelete("{postId}/comment/{commendId}")]
        public ActionResult<Post> Delete(int postId, int commentId, [FromBody] Comment comment)
        {
            // find post by postId, then find comment
            if (_postRepo.GetPostById(postId) is Post post)
            {
                Post postUpdatedComment = _postRepo.DeleteCommentById(commentId, comment);
                return Ok(postUpdatedComment);
            }
            return NotFound();
        }

    }
}
