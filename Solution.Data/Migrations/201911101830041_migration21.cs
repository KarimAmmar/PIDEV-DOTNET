namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            AddColumn("dbo.Interviews", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Interviews", "Interview_Type", c => c.Int(nullable: false));
            CreateIndex("dbo.Availabilities", "Representator_Id");
            CreateIndex("dbo.Interviews", "User_Id");
            CreateIndex("dbo.Interviews", "Candidat_Id");
            AddForeignKey("dbo.Availabilities", "Representator_Id", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Interviews", "Candidat_Id", "dbo.Candidates", "CandidateId");
            AddForeignKey("dbo.Interviews", "User_Id", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "QuizId", "dbo.Quizs", "QuizId");
            DropColumn("dbo.Interviews", "Compnay_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interviews", "Compnay_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Interviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Interviews", "Candidat_Id", "dbo.Candidates");
            DropForeignKey("dbo.Availabilities", "Representator_Id", "dbo.Users");
            DropIndex("dbo.Interviews", new[] { "Candidat_Id" });
            DropIndex("dbo.Interviews", new[] { "User_Id" });
            DropIndex("dbo.Availabilities", new[] { "Representator_Id" });
            AlterColumn("dbo.Interviews", "Interview_Type", c => c.String());
            DropColumn("dbo.Interviews", "User_Id");
            AddForeignKey("dbo.Questions", "QuizId", "dbo.Quizs", "QuizId", cascadeDelete: true);
        }
    }
}
