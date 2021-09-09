namespace CourseTests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationPossibleAnswerAndUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPossibleAnswers",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        PossibleAnswer_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.PossibleAnswer_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.PossibleAnswers", t => t.PossibleAnswer_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.PossibleAnswer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPossibleAnswers", "PossibleAnswer_Id", "dbo.PossibleAnswers");
            DropForeignKey("dbo.UserPossibleAnswers", "User_Id", "dbo.Users");
            DropIndex("dbo.UserPossibleAnswers", new[] { "PossibleAnswer_Id" });
            DropIndex("dbo.UserPossibleAnswers", new[] { "User_Id" });
            DropTable("dbo.UserPossibleAnswers");
        }
    }
}
