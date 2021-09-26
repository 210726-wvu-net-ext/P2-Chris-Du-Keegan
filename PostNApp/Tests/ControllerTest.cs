using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using PostN.WebApi.Controllers;
using PostN.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PostN.DataAccess;
using PostN.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Entity = PostN.DataAccess.Entities;
using System.Collections.Generic;
using Post = PostN.Domain.Post;
using PostN.WebApi.Models;

namespace Tests
{
    public class ControllerTest
    {
        private readonly DbContextOptions<CMKWDTP2Context> options;

        public ControllerTest()
        {
            options = new DbContextOptionsBuilder<CMKWDTP2Context>().UseSqlite("Filename=Test4.db").Options;
            Seed();
        
        }
        /*[Fact]
        public void ProveThatUserControllerIsCalled()
        {
            var logger = new Mock<ILogger<UserController>>();
            var mockRepo = new Mock<IUserRepo>();
        
            var userController = new UserController(mockRepo.Object, logger.Object);
        
            var result = userController.GetUsers();
        
            var viewResult = Assert.IsType<ViewResult>(result);
            int i = result.Result.Count;
            Assert.Equal(viewResult.Count, result.Count);
        
        }*/

        [Fact]
        public void ProveThatPostControllerIsCalled()
        {
            var logger = new Mock<ILogger<PostController>>();
            var mockRepo = new Mock<IPostRepo>();
        
            var postController = new PostController(mockRepo.Object, logger.Object);
        
            var result = postController.Get();
            
            var viewResult = Assert.IsType<ViewResult>(result);
            
            Assert.Equal(viewResult, result.Result);
        
        }

        [Fact]
        public async Task CreatePost_ReturnsNewPost()
        {
            // Arrange
            var logger = new Mock<ILogger<PostController>>();
            var post = new Post
            {
                Id = 1,
                UserId = 5,
                Image = null,
                Created = DateTime.Now,
                Title = "Mock Title",
                Body = "Mock Body",
                Username = "kwedwick"
            };
            var mockRepo = new Mock<IPostRepo>();
            mockRepo.Setup(repo => repo.CreatePost(post)).ReturnsAsync(post);
            var controller = new PostController(mockRepo.Object, logger.Object);
            var model = new CreatedPost { UserId = post.UserId, Image = post.Image, Title = post.Title, Body = post.Body, Username = post.Username };

            // Act
            Task<ActionResult<Post>> result = controller.Post(model);
            

            // Assert
            //int Id = result.Id;
            Assert.Equal(result.Id, post.Id);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            var logger = new Mock<ILogger<PostController>>();
            var mockRepo = new Mock<IPostRepo>();
            using (var testcontext = new CMKWDTP2Context(options))
            {
                IPostRepo _repo = new PostRepo(testcontext);
                var testPost = _repo.GetAllPosts();
                mockRepo.Setup(repo => repo.GetAllPosts()).Returns(testPost);
                var controller = new PostController(mockRepo.Object, logger.Object);


                Task<ActionResult<Post>> result = controller.Get();

                Assert.Equal(testPost.Result, (IEnumerable<Post>)result);


            }
            
        }

        /*[Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts2()
        {
            // arrange
            var logger = new Mock<ILogger<PostController>>();
            var mockRepo = new Mock<IPostRepo>();
            using (var testcontext = new CMKWDTP2Context(options))
            {
                IPostRepo _repo = new PostRepo(testcontext);
                var controller = new PostController(mockRepo.Object, logger.Object);
                var testPost = _repo.GetAllPosts();

                // act
                Task<ActionResult<Post>> result = controller.Get();
                //var okResult = Assert.IsType<Task<Post>>(result);

                // assert
                Assert.NotNull(result);
                Assert.Equal(testPost.Result, (IEnumerable<Post>)result.Result.Result);

            }
                

        }*/

        /* [Fact]
         public void ProveThatPostControllerIsCalled()
         {
             var logger = new Mock<ILogger<PostController>>();
            var mockRepo = new Mock<IPostRepo>();

           var PostController = new PostController(mockRepo.Object, logger.Object);

             var result = PostController.Get();
           int x = result.Result.Count;
           using (var testcontext = new CMKWDTP2Context(options))
            {
                IPostRepo _repo = new PostRepo(testcontext);

               //Act
                var repoResult = _repo.GetAllPosts();
                 var viewResult = Assert.IsType<ViewResult>(result); }
                 //int i = repoResult.Result.Count;
                 Assert.Equal(repoResult.Result.Count, result);

             }*/

        private void Seed()
        {
            using (var context = new Entity.CMKWDTP2Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Users.AddRange(
                    new Entity.User
                    {
                        Id = 1,
                        FirstName = "Keegan",
                        LastName = "Wedwick",
                        Email = "kwedwick@gmail.com",
                        Username = "kwedwick",
                        Password = "password",
                        AboutMe = "Keegan About Me",
                        State = "WI",
                        Country = "USA",
                        Role = "Administrator",
                        PhoneNumber = "608-479-1147",
                        DoB = System.DateTime.Today
                    }
                    ,
                    new Entity.User
                    {
                        Id = 2,
                        FirstName = "Christopher",
                        LastName = "Mesidor",
                        Email = "cMesidor@gmail.com",
                        Username = "cmesidor",
                        Password = "password1234",
                        AboutMe = "New .NET developer",
                        State = "NY",
                        Country = "USA",
                        Role = "Administrator",
                        PhoneNumber = "123-456-1234",
                        DoB = System.DateTime.Today
                    },
                    new Entity.User
                    {
                        Id = 3,
                        FirstName = "Du",
                        LastName = "Tran",
                        Email = "dTran@gmail.com",
                        Username = "dTran",
                        Password = "password",
                        AboutMe = "New ASP.NET developer",
                        State = "MA",
                        Country = "USA",
                        Role = "Administrator",
                        PhoneNumber = "789-123-1111",
                        DoB = System.DateTime.Today

                    },
                    new Entity.User
                    {
                        Id = 4,
                        FirstName = "Elizabeth",
                        LastName = "Jackson",
                        Email = "eJackson@gmail.com",
                        Username = "ejackson",
                        Password = "password",
                        AboutMe = "New JavasScript developer",
                        State = "CA",
                        Country = "USA",
                        Role = "User",
                        PhoneNumber = "399-555-1928",
                        DoB = System.DateTime.Today

                    }
                );


                context.Posts.AddRange(
                    new Entity.Post
                    {
                        Id = 1,
                        UserId = 1,
                        Created = DateTime.Now,
                        Title = "Keegan first title",
                        Body = "This is Keegan''s post body!"
                    },
                    new Entity.Post
                    {
                        Id = 2,
                        UserId = 2,
                        Created = DateTime.Now,
                        Title = "Chris first title",
                        Body = "This is Chris''s post body!"
                    },
                    new Entity.Post
                    {
                        Id = 3,
                        UserId = 3,
                        Created = DateTime.Now,
                        Title = "Du first title",
                        Body = "This is Du''s post body!"
                    },
                    new Entity.Post
                    {
                        Id = 4,
                        UserId = 4,
                        Created = DateTime.Now,
                        Title = "Elizabeth first title",
                        Body = "This is Elizabeth''s post body!"
                    }
                ); ;

                context.Comments.AddRange(
                    new Entity.Comment
                    {
                        Id = 1,
                        UserId = 2,
                        PostId = 1,
                        Created = DateTime.Now,
                        CommentBody = "Great post Keegan! - Chris"
                    },
                    new Entity.Comment
                    {
                        Id = 2,
                        UserId = 3,
                        PostId = 2,
                        Created = DateTime.Now,
                        CommentBody = "Great post Chris! - Du"
                    },
                    new Entity.Comment
                    {
                        Id = 3,
                        UserId = 4,
                        PostId = 3,
                        Created = DateTime.Now,
                        CommentBody = "Great post Du! - Elizabeth"
                    },
                    new Entity.Comment
                    {
                        Id = 4,
                        UserId = 1,
                        PostId = 4,
                        Created = DateTime.Now,
                        CommentBody = "Great post Elizabeth! - Keegan"
                    }
                );

                context.Followers.AddRange(
                    new Entity.Follower
                    {
                        Id = 1,
                        UserId = 1,
                        UserId2 = 2,
                        FriendRequest = 1,
                    },
                    new Entity.Follower
                    {
                        Id = 2,
                        UserId = 2,
                        UserId2 = 3,
                        FriendRequest = 1,
                    },
                    new Entity.Follower
                    {
                        Id = 3,
                        UserId = 3,
                        UserId2 = 4,
                        FriendRequest = 1,
                    },
                    new Entity.Follower
                    {
                        Id = 4,
                        UserId = 4,
                        UserId2 = 1,
                        FriendRequest = 1,
                    }
                );
                context.SaveChanges();
            }
        }

    }


        
}

