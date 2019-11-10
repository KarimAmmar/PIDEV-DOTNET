using Solution.Data.Configurations;
using Solution.Data.CustomConventions;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=Recrutment")
        {

        }
        //DbSet<> ...
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Availability> Availibilities { get; set; }
     
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Offer> Offers { get; set; }

        // public DbSet<Offre> Candidates { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CandidateConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new QuizConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Conventions.Add(new DateTimeConvention());
        }
    }
}
