using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostN.Domain;
using PostN.DataAccess;
using PostN.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class UnitTest2
    {

        private readonly DbContextOptions<CMKWDTP2Context> options;

        public UnitTest2()
        {
            options = new DbContextOptionsBuilder<CMKWDTP2Context>().UseSqlite("Filename=Test.db").Options;
            //Seed();
        }
       
        [Fact]
        public void EmailShouldBeUnique()
        {
            using (var testcontext2 = new CMKWDTP2Context(options))
            {
                IUserRepo _repo = new UserRepo(testcontext2);

                bool result = _repo.UniqueEmail("dTran@gmail.com");
                Assert.True(result, "expect to be true");
            }

        }
        [Fact]
        public void UsernameShouldBeUnique()
        {
            using (var testcontext1 = new CMKWDTP2Context(options))
            {
                IUserRepo _repo = new UserRepo(testcontext1);

                bool result = _repo.UniqueUsername("dtran");
                Assert.True(result, "expect to be true");
            }

        }
        //private void Seed()
        //{
        //    using (var context = new CMKWDTP2Context(options))
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();
        //        context.SaveChanges();
        //    }
        //}
    }
}