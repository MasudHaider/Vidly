namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
USE [Vidly]
GO

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
           ,[UserName])
     VALUES(
N'a641c1c0-61bf-4e0e-8e59-9765f3455c55',N'guest@vidly.com',0,N'ADLp2dIzA1cSoleYeQ8GP+fZaiRNcZF7OyEp3EllWw/p6WGhIhHXenxYu/GM135s6g==',N'1a392f35-065a-4fa4-8151-1d4b4017368e',NULL,0,0,NULL,1,0,N'guest@vidly.com')
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
           ,[UserName])
     VALUES(N'c6044a93-c718-41ae-97f5-9534c3b11bfe',N'admin@vidly.com',	0,	N'AJ8Q+nY0Yvozgjue7VViXuU6w7b8CATk6dc0oeqm3WbmSkgLxrpoCppjyTOpfxuxTg==',	N'b44b2b60-5fae-41fc-83c7-c3db4855e9c8',	NULL,	0,	0,	NULL,	1,	0,	N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles]([Id],[Name]) VALUES(N'69d9f008-b9ce-43c4-aa50-69ab2805b0ac', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles]([UserId],[RoleId]) VALUES(N'c6044a93-c718-41ae-97f5-9534c3b11bfe',N'69d9f008-b9ce-43c4-aa50-69ab2805b0ac')

");
        }

        public override void Down()
        {
        }
    }
}
