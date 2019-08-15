namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDatesAndSeasonToSerie : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Series SET ReleaseDate = '2018 - 01 - 01' WHERE Id = 1");
            Sql("UPDATE Series SET ReleaseDate = '2017 - 02 - 02' WHERE Id = 2");
            Sql("UPDATE Series SET ReleaseDate = '2016 - 01 - 02' WHERE Id = 3");
            Sql("UPDATE Series SET ReleaseDate = '2018 - 03 - 10' WHERE Id = 4");

            Sql("UPDATE Series SET DateAdded = '2018 - 03 - 30' WHERE Id = 1");
            Sql("UPDATE Series SET DateAdded = '2018 - 04 - 25' WHERE Id = 2");
            Sql("UPDATE Series SET DateAdded = '2016 - 05 - 10' WHERE Id = 3");
            Sql("UPDATE Series SET DateAdded = '2018 - 03 - 30' WHERE Id = 4");

            Sql("UPDATE Series SET Season = 'FIVE' WHERE Id = 1");
            Sql("UPDATE Series SET Season = 'TEN' WHERE Id = 2");
            Sql("UPDATE Series SET Season = 'THREE' WHERE Id = 3");
            Sql("UPDATE Series SET Season = 'ONE' WHERE Id = 4");

        }
        
        public override void Down()
        {
        }
    }
}
