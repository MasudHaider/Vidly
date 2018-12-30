namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate=2008-02-08, DateAdded=2012-03-13 WHERE Id = 4");
            Sql("UPDATE Movies SET ReleaseDate=2009-02-08, DateAdded=2012-03-13 WHERE Id = 5");
            Sql("UPDATE Movies SET ReleaseDate=2010-02-08, DateAdded=2013-03-13 WHERE Id = 6");
            Sql("UPDATE Movies SET ReleaseDate=2010-02-08, DateAdded=2013-03-13 WHERE Id = 7");
        }

        public override void Down()
        {
        }
    }
}
