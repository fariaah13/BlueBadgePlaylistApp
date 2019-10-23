namespace Playlist.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaylistData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NewPlaylist", "OwnerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewPlaylist", "OwnerID", c => c.Guid(nullable: false));
        }
    }
}
