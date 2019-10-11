namespace Playlist.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                        AlbumArt = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumID);
            
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsBand = c.Boolean(nullable: false),
                        CountryOfOrigin = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.SongPlaylist",
                c => new
                    {
                        SongPlaylistID = c.Int(nullable: false, identity: true),
                        ArtistID = c.Int(nullable: false),
                        SongID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SongPlaylistID);
            
            CreateTable(
                "dbo.NewPlaylist",
                c => new
                    {
                        NewPlaylistID = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.NewPlaylistID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        ArtistID = c.Int(nullable: false),
                        Runtime = c.Int(nullable: false),
                        Language = c.String(),
                        AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SongID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Song");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.NewPlaylist");
            DropTable("dbo.SongPlaylist");
            DropTable("dbo.Artist");
            DropTable("dbo.Album");
        }
    }
}
