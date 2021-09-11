﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostN.Domain
{
    public interface IUserRepo
    {
        List<Users> GetUsers();
        List<Followers> GetFollowers();
    }
}