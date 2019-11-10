using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class CommentService : Service<Comment>, ICommentService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public CommentService() : base(UTK)
        {

        }
        public IEnumerable<Comment> GetCommentByPost(int IdPost)
        {
            return GetMany(c => c.PostId == IdPost);
        }
    }
}
