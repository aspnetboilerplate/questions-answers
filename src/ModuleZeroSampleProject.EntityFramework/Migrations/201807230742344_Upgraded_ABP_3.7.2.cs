namespace ModuleZeroSampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_ABP_372 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "PhoneNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.AbpUsers", "SecurityStamp", c => c.String(maxLength: 128));
            AlterColumn("dbo.AbpAuditLogs", "BrowserInfo", c => c.String(maxLength: 512));
            AlterColumn("dbo.AbpUserLoginAttempts", "BrowserInfo", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUserLoginAttempts", "BrowserInfo", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpAuditLogs", "BrowserInfo", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpUsers", "SecurityStamp", c => c.String());
            AlterColumn("dbo.AbpUsers", "PhoneNumber", c => c.String());
        }
    }
}
