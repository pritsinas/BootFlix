namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (3, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES (4, 'Thriller')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
