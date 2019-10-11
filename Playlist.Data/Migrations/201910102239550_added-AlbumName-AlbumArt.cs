namespace Playlist.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAlbumNameAlbumArt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Album", "AlbumName", c => c.String(nullable: false));
            AlterColumn("dbo.Album", "AlbumArt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Album", "AlbumArt", c => c.Int(nullable: false));
            AlterColumn("dbo.Album", "AlbumName", c => c.String());
        }
    }
}
