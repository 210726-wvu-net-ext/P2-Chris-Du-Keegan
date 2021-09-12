using Microsoft.EntityFrameworkCore;
using PostN.DataAccess.Entities;
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
        private readonly CMKWDTP2Context _context;
        public PostRepo(CMKWDTP2Context context)
        {
            _context = context;
        }


        /*public List<Domain.Post> GetPost()
        {
            return _context.Posts.Select(
                users => new Domain.Post(users.Id, users.UserId, users.Image, users.Created, users.Title, users.Body)
            ).ToList();
        }*/

        public async Task<Domain.Comment> CreateCommentByPostId(int postId, Domain.Comment comment)
        {

            var newEntity = new Entities.Comment
            {
                UserId = comment.UserId,
                PostId = comment.PostId,
                CommentBody = comment.CommentBody
            };
            await _context.Comments.AddAsync(newEntity);
            _context.SaveChanges();
            comment.Id = newEntity.Id;
            return comment;
        }

        public async Task<Domain.Post> CreatePost(Domain.Post post)
        {
            var newEntity = new Entities.Post
            {
                UserId = post.UserId,
                Image = post.Image,
                Created = post.Created,
                Title = post.Title,
                Body = post.Body,
            };
            await _context.Posts.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            post.Id = newEntity.Id;
            return post;
        }

        public Domain.Post DeleteCommentById(int commentId, Domain.Comment comment)
        {
            var commentToDelete = _context.Comments.Single(c => c.Id == commentId);
            if (commentToDelete != null)
            {
                _context.Remove(commentToDelete);
                _context.SaveChanges();
                return new Domain.Post();
            }

            return new Domain.Post();
        }

        public Domain.Post DeletePostById(int id, Domain.Post post)
        {

            var postToDelete = _context.Posts.Single(p => p.Id == id);
            if (postToDelete != null)
            {
                _context.Remove(postToDelete);
                _context.SaveChanges();
                return new Domain.Post();
            }

            return new Domain.Post();
        }

        public Task<List<Domain.Post>> GetAllPosts()
        {
            try
            {
                return Task.FromResult(_context.Posts
                .Include(u => u.User)
                .ThenInclude(c => c.Comments)
                .Select(p => new Domain.Post
                {
                    Id = p.Id,
                    UserId = p.User.Id,
                    Username = p.User.Username,
                    Image = p.Image,
                    Title = p.Title,
                    Body = p.Body,
                    Comments = p.Comments.Select(k => new Domain.Comment(k.Id, k.UserId, k.PostId, k.User.Username, k.Created, k.CommentBody)).ToList()
                }).ToList());
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.FromResult(new List<Domain.Post>());
            }
            
            //throw new NotImplementedException();
        }

        public Task<Domain.Post> GetPostById(int id)
        {
            try
            {
                var returnedPosts = _context.Posts
                .Include(u => u.User)
                .ThenInclude(c => c.Comments)
                .Select(p => new Domain.Post
                {
                    Id = p.Id,
                    Username = p.User.Username,
                    Image = p.Image,
                    Title = p.Title,
                    Body = p.Body,
                    Comments = p.Comments.Select(k => new Domain.Comment(k.Id, k.UserId, k.PostId, k.User.Username, k.Created, k.CommentBody)).ToList()
                }).ToList();

                Domain.Post singlePost = returnedPosts.FirstOrDefault(p => p.Id == id);
                return Task.FromResult(singlePost);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return Task.FromResult(new Domain.Post());
            }
            

        }

        public Task<Domain.Post> UpdateCommentById(int commentId, Domain.Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Post> UpdatePostById(int id, Domain.Post post)
        {
           
            throw new NotImplementedException();
        }
    }
}
