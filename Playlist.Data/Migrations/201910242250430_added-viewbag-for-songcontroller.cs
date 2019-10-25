namespace Playlist.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedviewbagforsongcontroller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SongPlaylist", "NewPlaylistID", c => c.Int(nullable: false));
            CreateIndex("dbo.SongPlaylist", "NewPlaylistID");
            CreateIndex("dbo.SongPlaylist", "SongID");
            AddForeignKey("dbo.SongPlaylist", "NewPlaylistID", "dbo.NewPlaylist", "NewPlaylistID", cascadeDelete: true);
            AddForeignKey("dbo.SongPlaylist", "SongID", "dbo.Song", "SongID", cascadeDelete: true);
            DropColumn("dbo.SongPlaylist", "ArtistID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SongPlaylist", "ArtistID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SongPlaylist", "SongID", "dbo.Song");
            DropForeignKey("dbo.SongPlaylist", "NewPlaylistID", "dbo.NewPlaylist");
            DropIndex("dbo.SongPlaylist", new[] { "SongID" });
            DropIndex("dbo.SongPlaylist", new[] { "NewPlaylistID" });
            DropColumn("dbo.SongPlaylist", "NewPlaylistID");
        }
    }
}
