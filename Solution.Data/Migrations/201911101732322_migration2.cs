namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Company_Address", c => c.String());
            AddColumn("dbo.Events", "Event_Address", c => c.String());
            AlterColumn("dbo.Companies", "Company_Number", c => c.String());
            AlterColumn("dbo.Companies", "NumberOfEmployees", c => c.String());
            AlterColumn("dbo.Offers", "Offer_Contract_Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Offers", "Offer_Level_Of_Expertise", c => c.Int(nullable: false));
            DropColumn("dbo.Offers", "Validity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "Validity", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Offers", "Offer_Level_Of_Expertise", c => c.String());
            AlterColumn("dbo.Offers", "Offer_Contract_Type", c => c.String());
            AlterColumn("dbo.Companies", "NumberOfEmployees", c => c.Int(nullable: false));
            AlterColumn("dbo.Companies", "Company_Number", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Event_Address");
            DropColumn("dbo.Companies", "Company_Address");
        }
    }
}
