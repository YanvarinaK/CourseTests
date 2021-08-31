namespace CourseTests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoursesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CourseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        TestId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.PossibleAnswers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsRight = c.Boolean(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.PossibleAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Tests", "CourseId", "dbo.Courses");
            DropIndex("dbo.PossibleAnswers", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "TestId" });
            DropIndex("dbo.Tests", new[] { "CourseId" });
            DropTable("dbo.PossibleAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.Tests");
            DropTable("dbo.Courses");
        }
    }
}
