using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasMany(usr => usr.Interviews).
                         WithRequired(inter => inter.user).//prop nav
                         HasForeignKey(inter => inter.User_Id).//prop nav
                         WillCascadeOnDelete(false);

            HasMany(usr => usr.Availabilities).
                        WithRequired(avail => avail.user).//prop nav
                        HasForeignKey(avail => avail.Representator_Id).//prop nav
                        WillCascadeOnDelete(false);
        }
    }
}
