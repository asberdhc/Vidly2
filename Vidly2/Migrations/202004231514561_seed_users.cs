namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed_users : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'086ebbe8-5530-4f67-abee-4c99fbdf5f19', N'moviesAdmin@pro.com', 0, N'ACO2CS1YTwJ10hsXyWciMroM9ej/YwxrWXDIXm0ySgnqWWTDGAMMQsT4pzKrolUFlg==', N'2feccbfe-8408-4052-930a-3a5688c4434e', NULL, 0, 0, NULL, 1, 0, N'moviesAdmin@pro.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5592ae3b-2d41-4935-b941-58fd14cae4b6', N'ale@pro.com', 0, N'ACxkncts25aBOA+zTP3nTePmR7np+soQ7oSqWKYEkbcPcIV+9KhtMO95XoyNsXapkw==', N'ff108ee0-98d6-4ef7-8507-dbdffca3ecdd', NULL, 0, 0, NULL, 1, 0, N'ale@pro.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'82b67a09-b424-4bae-8e93-f399da7d8e4a', N'admin@pro.com', 0, N'AFjDrZBe93b8X7977RVHFEA08hBwue1xtUXlZMYdrvMonjbPCBeHRTmv9YGfnQx89g==', N'e3a1a817-26ff-4edd-884a-f9cdfa649427', NULL, 0, 0, NULL, 1, 0, N'admin@pro.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'745f1fbe-65f8-43f1-a701-19a2563ebb1f', N'CanChangeMovies')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2922f7cc-29c0-45be-a3b8-2b90b59e88c0', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'086ebbe8-5530-4f67-abee-4c99fbdf5f19', N'2922f7cc-29c0-45be-a3b8-2b90b59e88c0')

");
        }
        
        public override void Down()
        {
        }
    }
}
