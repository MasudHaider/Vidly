namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[Email]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEndDateUtc]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName]) VALUES(N'53f7702d-ce06-4150-80c9-b28f5739c332',	N'guest@vidly.com',	0,	N'AJs1TRxBaw72xIk1PBhSVUVAPwIDFtwfLdhnvsyGLD1UUAq3NUtKj7WKTVxw4SHmDw==',	N'f0a09ff7-bde7-462e-a2a6-f84744587fa1',	NULL,	0,	0,	NULL,	1,	0,	N'guest@vidly.com')

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[Email]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEndDateUtc]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName]) VALUES(N'9876eec8-283c-41b7-a22a-cfc506385b4e',	N'admin@vidly.com',	0,	N'ABVyYwaVYhYtMwohON9GSR5tUQOMFzcSwf8UO0vKlyxyWB/V0MQp9yuwSFKiNHxy6g==',	N'9dd335dc-b6a3-409c-a21c-802dd2f68d92',	NULL,	0,	0,	NULL,	1,	0,	N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]) VALUES(N'94bac008-548c-465e-baf3-ecd490559d07',	N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId]) VALUES(N'9876eec8-283c-41b7-a22a-cfc506385b4e',	N'94bac008-548c-465e-baf3-ecd490559d07')

");
        }
        
        public override void Down()
        {
        }
    }
}
