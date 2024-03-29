﻿using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class PostService : Service<Post>, IPostService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public PostService() : base(UTK)
        {

        }
        public void LikePost(int IdPost)
        {
            GetById(IdPost).NbrLikes = GetById(IdPost).NbrLikes + 1;
        }
        public void DisLikePost(int IdPost)
        {
            GetById(IdPost).NbrLikes = GetById(IdPost).NbrLikes - 1;
        }

        
    }
}
