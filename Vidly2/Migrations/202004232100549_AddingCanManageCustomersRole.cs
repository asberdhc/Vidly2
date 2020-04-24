namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCanManageCustomersRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3922f7cc-29c0-45be-a3b8-2b90b59e88c0', N'TotalControl')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'82b67a09-b424-4bae-8e93-f399da7d8e4a', N'3922f7cc-29c0-45be-a3b8-2b90b59e88c0')
");
        }
        
        public override void Down()
        {
        }
    }
}
