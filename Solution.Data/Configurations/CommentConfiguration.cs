using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration() { 
        HasOptional(com => com.Post).WithMany(pos => pos.Comments).HasForeignKey(com => com.PostId).
            WillCascadeOnDelete(true);
    }
    }
}
