namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbase : DbMigration
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
                        Name = c.String(),
                        Nbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CertificationId);
            
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
                    })
                .PrimaryKey(t => t.DiplomaId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ExperienceId = c.Int(nullable: false, identity: true),
                        Nbr = c.Int(nullable: false),
                        field = c.String(),
                        CandidateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExperienceId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewId = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Candidat_Id = c.Int(nullable: false),
                        Interview_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Interview_Location = c.String(),
                        Interview_Type = c.String(),
                    })
                .PrimaryKey(t => t.InterviewId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Candidates", t => t.Candidat_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Candidat_Id);
            
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
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        languageName = c.String(),
                        Nbr = c.Int(nullable: false),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.LanguageId);
            
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
                .ForeignKey("dbo.Quizs", t => t.QuizId)
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
                "dbo.CertificationOfCandidate",
                c => new
                    {
                        Certification = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Certification, t.Candidate })
                .ForeignKey("dbo.Candidates", t => t.Certification, cascadeDelete: true)
                .ForeignKey("dbo.Certifications", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Certification)
                .Index(t => t.Candidate);
            
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
                "dbo.DiplomaOfCandidate",
                c => new
                    {
                        Diploma = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Diploma, t.Candidate })
                .ForeignKey("dbo.Candidates", t => t.Diploma, cascadeDelete: true)
                .ForeignKey("dbo.Diplomata", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Diploma)
                .Index(t => t.Candidate);
            
            CreateTable(
                "dbo.Knowledge",
                c => new
                    {
                        Language = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language, t.Candidate })
                .ForeignKey("dbo.Candidates", t => t.Language, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Candidate, cascadeDelete: true)
                .Index(t => t.Language)
                .Index(t => t.Candidate);
            
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
            DropForeignKey("dbo.OffresOfCandidate", "Candidate", "dbo.Offers");
            DropForeignKey("dbo.OffresOfCandidate", "Offres", "dbo.Candidates");
            DropForeignKey("dbo.Knowledge", "Candidate", "dbo.Languages");
            DropForeignKey("dbo.Knowledge", "Language", "dbo.Candidates");
            DropForeignKey("dbo.Interviews", "Candidat_Id", "dbo.Candidates");
            DropForeignKey("dbo.Interviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Experiences", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.DiplomaOfCandidate", "Candidate", "dbo.Diplomata");
            DropForeignKey("dbo.DiplomaOfCandidate", "Diploma", "dbo.Candidates");
            DropForeignKey("dbo.Subscribers", "Candidate", "dbo.Companies");
            DropForeignKey("dbo.Subscribers", "Company", "dbo.Candidates");
            DropForeignKey("dbo.Offers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Events", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CertificationOfCandidate", "Candidate", "dbo.Certifications");
            DropForeignKey("dbo.CertificationOfCandidate", "Certification", "dbo.Candidates");
            DropIndex("dbo.OffresOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.OffresOfCandidate", new[] { "Offres" });
            DropIndex("dbo.Knowledge", new[] { "Candidate" });
            DropIndex("dbo.Knowledge", new[] { "Language" });
            DropIndex("dbo.DiplomaOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.DiplomaOfCandidate", new[] { "Diploma" });
            DropIndex("dbo.Subscribers", new[] { "Candidate" });
            DropIndex("dbo.Subscribers", new[] { "Company" });
            DropIndex("dbo.CertificationOfCandidate", new[] { "Candidate" });
            DropIndex("dbo.CertificationOfCandidate", new[] { "Certification" });
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Payments", new[] { "UserId_UserId" });
            DropIndex("dbo.Claims", new[] { "UserId_UserId" });
            DropIndex("dbo.Interviews", new[] { "Candidat_Id" });
            DropIndex("dbo.Interviews", new[] { "User_Id" });
            DropIndex("dbo.Experiences", new[] { "CandidateId" });
            DropIndex("dbo.Offers", new[] { "CompanyId" });
            DropIndex("dbo.Events", new[] { "CompanyId" });
            DropTable("dbo.OffresOfCandidate");
            DropTable("dbo.Knowledge");
            DropTable("dbo.DiplomaOfCandidate");
            DropTable("dbo.Subscribers");
            DropTable("dbo.CertificationOfCandidate");
            DropTable("dbo.Reactions");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Payments");
            DropTable("dbo.Notifications");
            DropTable("dbo.Messages");
            DropTable("dbo.Claims");
            DropTable("dbo.Languages");
            DropTable("dbo.Users");
            DropTable("dbo.Interviews");
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
