<<<<<<< HEAD
﻿using PostN.DataAccess.Entities;
=======
﻿using Microsoft.EntityFrameworkCore;
using PostN.DataAccess.Entities;
>>>>>>> Develop
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
<<<<<<< HEAD
        public PostRepo(CMKWDTP2Context context)
        {
            _context = context;
        }

        public List<Domain.Post> GetPost()
        {
            return _context.Posts.Select(
                users => new Domain.Post(users.Id, users.UserId, users.Image, users.Created, users.Title, users.Body)
            ).ToList();
=======

        public PostRepo (CMKWDTP2Context context)
        {
            _context = context;
        }
        public Domain.Post CreateCommentByPostId(int postId, Domain.Comment comment)
        {
            
            throw new NotImplementedException();
        }

        public Domain.Post CreatePost(Domain.Post post)
        {
            throw new NotImplementedException();
        }

        public Domain.Post DeleteCommentById(int commentId, Domain.Comment comment)
        {
            throw new NotImplementedException();
        }

        public Domain.Post DeletePostById(int id, Domain.Post post)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Post> GetAllPosts()
        {

            return _context.Posts
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
            //throw new NotImplementedException();
        }

        public Domain.Post GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.Post UpdateCommentById(int commentId, Domain.Comment comment)
        {
            throw new NotImplementedException();
        }

        public Domain.Post UpdatePostById(int id, Domain.Post post)
        {
            throw new NotImplementedException();
>>>>>>> Develop
        }
    }
}
