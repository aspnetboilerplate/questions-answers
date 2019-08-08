namespace ModuleZeroSampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVoteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        UpVote = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.AbpUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Votes", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Votes", new[] { "QuestionId" });
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropTable("dbo.Votes");
        }
    }
}
