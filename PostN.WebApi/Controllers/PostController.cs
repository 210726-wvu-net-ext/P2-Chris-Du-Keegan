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
        // GET: api/post
        /// <summary>
        /// Get's all Posts with Comments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Post>> Get()
        {
            List<Post> Post = await _postRepo.GetAllPosts();
            return Ok(Post);
        }

        // GET api/post/5
        /// <summary>
        /// GET one post w/ comments by Post ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            if (await _postRepo.GetPostById(id) is Post singlePost)
            {
                return Ok(singlePost);
            }
            return NotFound();
        }

        // POST api/post
        /// <summary>
        /// Create a POST using Post body
        /// </summary>
        /// <param name="viewPost"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Post>> Post([FromBody] CreatedPost viewPost)
        {
            //need to check if user is logged in. need user's ID
            //return the new post information - route them to that specific post
            if(viewPost != null)
            {
                var post = new Post
                {
                    UserId = viewPost.UserId,
                    Image = viewPost.Image,
                    Created = DateTime.Now,
                    Title = viewPost.Title,
                    Body = viewPost.Body,
                    Username = viewPost.Username
                };
                try
                {
                    Post newPost = await _postRepo.CreatePost(post);
                    return Ok(newPost);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
            return NotFound();
        }

        // PUT api/post/5
        /// <summary>
        /// Update Post using Post URL ID and post body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Post>> Put(int id, [FromBody] Post post)
        {
            if (await _postRepo.GetPostById(id) is Post oldPost)
            {
                oldPost.Title = post.Title;
                oldPost.Image = post.Image;
                oldPost.Body = post.Body;

                Post updatedPost = await _postRepo.UpdatePostById(id, oldPost);
                return Ok(updatedPost);
            }
            return NotFound();
        }

        // DELETE api/post/5
        /// <summary>
        /// Delete post by POST ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _postRepo.GetPostById(id) is Post post)
            {
                _postRepo.DeletePostById(id, post);
                return NoContent();
            }
            return NotFound();
        }
        /// <summary>
        /// Create a comment using POST ID
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpGet("{postId}/comment")]
        public async Task<ActionResult<Post>> Post(int postId, [FromBody] CreatedComment comment)
        {
            if(await _postRepo.GetPostById(postId) is Post post)
            {
                var newComment = new Comment
                {
                    UserId = comment.UserId,
                    Username = comment.Username,
                    PostId = postId,
                    Created = DateTime.Now,
                    CommentBody = comment.CommentBody
                };
                await _postRepo.CreateCommentByPostId(postId, newComment);
                return Ok(post);
            }
            return NotFound();
        }

        /// <summary>
        /// Update Comment by Comment&Post ID
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPut("{postId}/comment/{commentId}")]
        public async Task<ActionResult<Post>> Put(int postId, int commentId, [FromBody] Comment comment)
        {
            // find post ID, then comment ID, then update comment
            if (await _postRepo.GetPostById(postId) is Post post)
            {
                Post postUpdatedComment = await _postRepo.UpdateCommentById(commentId, comment);
                return Ok(postUpdatedComment);
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Comment by Comment&Post ID - API Route
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpDelete("{postId}/comment/{commendId}")]
        public async Task<ActionResult<Post>> Delete(int postId, int commentId, [FromBody] Comment comment)
        {
            if (await _postRepo.GetPostById(postId) is Post post)
            {
                _postRepo.DeleteCommentById(commentId, comment);
                return Ok(post);
            }
            return NotFound();
        }

    }
}
