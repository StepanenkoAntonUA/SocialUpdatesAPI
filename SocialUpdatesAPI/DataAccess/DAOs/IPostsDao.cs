﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public interface IPostsDao 
    {
        Task<PlannedPost> SaveAsync(PlannedPost data);
        Task<List<PlannedPost>> GetPostsAsync(int delay);
    }
}
