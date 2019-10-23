namespace Playlist.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class songclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Song", "Title", c => c.String(nullable: false));
            CreateIndex("dbo.Song", "ArtistID");
            CreateIndex("dbo.Song", "AlbumID");
            AddForeignKey("dbo.Song", "AlbumID", "dbo.Album", "AlbumID", cascadeDelete: true);
            AddForeignKey("dbo.Song", "ArtistID", "dbo.Artist", "ArtistID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "ArtistID", "dbo.Artist");
            DropForeignKey("dbo.Song", "AlbumID", "dbo.Album");
            DropIndex("dbo.Song", new[] { "AlbumID" });
            DropIndex("dbo.Song", new[] { "ArtistID" });
            AlterColumn("dbo.Song", "Title", c => c.String());
        }
    }
}
