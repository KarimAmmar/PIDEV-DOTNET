namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Availabilities", "Representator_Id");
            AddForeignKey("dbo.Availabilities", "Representator_Id", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Availabilities", "Representator_Id", "dbo.Users");
            DropIndex("dbo.Availabilities", new[] { "Representator_Id" });
        }
    }
}
