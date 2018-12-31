namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenresData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET Name='Adventure' WHERE Id = 6");
            Sql("UPDATE Genres SET Name='Comedy' WHERE Id = 7");
            Sql("UPDATE Genres SET Name='Mystery' WHERE Id = 8");
            Sql("UPDATE Genres SET Name='Sci-Fi' WHERE Id = 9");
            Sql("UPDATE Genres SET Name='Animation' WHERE Id = 10");
        }

        public override void Down()
        {
        }
    }
}
