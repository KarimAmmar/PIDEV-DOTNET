namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        Candidat_Id = c.Int(nullable: false),
                        Job_Offer_Id = c.Int(nullable: false),
                        Application_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Application_Description = c.String(),
                        Application_Status = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        AvailabilityId = c.Int(nullable: false, identity: true),
                        Representator_Id = c.Int(nullable: false),
                        Availability_Date_Begin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Availability_Date_End = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.AvailabilityId);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        DateOfBirthday = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        ImageUrl = c.String(),
                        bio = c.String(),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        CertificationId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        DateObtained = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CredentialIdentification = c.String(),
                        CandidateId = c.Int(),
                    })
                .PrimaryKey(t => t.CertificationId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Company_Name = c.String(),
                        Company_Number = c.Int(nullable: false),
                        Company_Email = c.String(),
                        Company_Description = c.String(),
                        Company_Website = c.String(),
                        Company_Logo = c.String(),
                        NumberOfEmployees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Event_Title = c.String(),
                        Event_Description = c.String(),
                        Event_Organizer = c.String(),
                        Event_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfParticipent = c.Int(nullable: false),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        Offer_Title = c.String(),
                        Offer_description = c.String(),
                        Offre_Location = c.String(),
                        Offre_Duration = c.String(),
                        Offre_Salary = c.Single(nullable: false),
                        Offer_Contract_Type = c.String(),
                        Offer_Level_Of_Expertise = c.String(),
                        Offer_DatePublished = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Validity = c.Boolean(nullable: false),
                        Vues = c.Int(nullable: false),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Diplomata",
                c => new
                    {
                        DiplomaId = c.Int(nullable: false, identity: true),
                        DiplomaName = c.String(),
                        DiplomaSpeciality = c.String(),
                        ObtainingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DiplomaUniversity = c.String(),
                        CandidateId = c.Int(),
                    })
                .PrimaryKey(t => t.DiplomaId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CandidateId = c.Int(),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        rating = c.Single(nullable: false),
                        CandidateId = c.Int(),
                    })
                .PrimaryKey(t => t.SkillId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        Object_claim = c.String(),
                        Content_claim = c.String(),
                        Type_claim = c.String(),
                        Date_claim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TreatmentDate_claim = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        State_claim = c.String(),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        username = c.String(),
                        password = c.String(),
                        status = c.Int(nullable: false),
                        picture = c.String(nullable: false),
                        role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewId = c.Int(nullable: false, identity: true),
                        Compnay_Id = c.Int(nullable: false),
                        Candidat_Id = c.Int(nullable: false),
                        Interview_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Interview_Location = c.String(),
                        Interview_Type = c.String(),
                    })
                .PrimaryKey(t => t.InterviewId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Destination = c.Int(nullable: false),
                        DateSend = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        TypeNotification = c.String(),
                        Content = c.String(),
                        DateNotification = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.NotificationId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Amount_payment = c.Double(nullable: false),
                        Payment_date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        UrlImage = c.String(),
                        UrlVideo = c.String(),
                        PostDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NbrLikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        CommentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NbrLikes = c.Int(nullable: false),
                        PostId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Quiz_Id = c.Int(nullable: false),
                        Question_Value = c.Int(nullable: false),
                        Question_Description = c.String(),
                        Question_1stSuggestion = c.String(),
                        Question_2ndSuggestion = c.String(),
                        Question_3rdSuggestion = c.String(),
                        Question_Correct_Answer = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        Compnay_Id = c.Int(nullable: false),
                        Candidat_Id = c.Int(nullable: false),
                        Max_Score = c.Int(nullable: false),
                        Success_Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizId);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        ReactionId = c.Int(nullable: false, identity: true),
                        TypeReaction = c.String(),
                        PublicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReactionId);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Company = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Company, t.Candidate })
                .ForeignKey("dbo.Candidates", t => t.Company, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Company)
                .Index(t => t.Candidate);
            
            CreateTable(
                "dbo.contact",
                c => new
                    {
                        CandidateId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidateId, t.ContactId })
                .ForeignKey("dbo.Candidates", t => t.CandidateId)
                .ForeignKey("dbo.Candidates", t => t.ContactId)
                .Index(t => t.CandidateId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.OffresOfCandidate",
                c => new
                    {
                        Offres = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offres, t.Candidate })
                .ForeignKey("dbo.Candidates", t => t.Offres, cascadeDelete: true)
                .ForeignKey("dbo.Offers", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Offres)
                .Index(t => t.Candidate);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Payments", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Claims", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Skills", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.OffresOfCandidate", "Candidate", "dbo.Offers");
            DropForeignKey("dbo.OffresOfCandidate", "Offres", "dbo.Candidates");
            DropForeignKey("dbo.Experiences", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Diplomata", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.contact", "ContactId", "dbo.Candidates");
            DropForeignKey("dbo.contact", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Subscribers", "Candidate", "dbo.Companies");
            DropForeignKey("dbo.Subscribers", "Company", "dbo.Candidates");
            DropForeignKey("dbo.Offers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Events", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Certifications", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.OffresOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.OffresOfCandidate", new[] { "Offres" });
            DropIndex("dbo.contact", new[] { "ContactId" });
            DropIndex("dbo.contact", new[] { "CandidateId" });
            DropIndex("dbo.Subscribers", new[] { "Candidate" });
            DropIndex("dbo.Subscribers", new[] { "Company" });
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Payments", new[] { "UserId_UserId" });
            DropIndex("dbo.Claims", new[] { "UserId_UserId" });
            DropIndex("dbo.Skills", new[] { "CandidateId" });
            DropIndex("dbo.Experiences", new[] { "CandidateId" });
            DropIndex("dbo.Diplomata", new[] { "CandidateId" });
            DropIndex("dbo.Offers", new[] { "CompanyId" });
            DropIndex("dbo.Events", new[] { "CompanyId" });
            DropIndex("dbo.Certifications", new[] { "CandidateId" });
            DropTable("dbo.OffresOfCandidate");
            DropTable("dbo.contact");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Reactions");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Payments");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.Interviews");
            DropTable("dbo.Users");
            DropTable("dbo.Claims");
            DropTable("dbo.Skills");
            DropTable("dbo.Experiences");
            DropTable("dbo.Diplomata");
            DropTable("dbo.Offers");
            DropTable("dbo.Events");
            DropTable("dbo.Companies");
            DropTable("dbo.Certifications");
            DropTable("dbo.Candidates");
            DropTable("dbo.Availabilities");
            DropTable("dbo.Applications");
        }
    }
}
