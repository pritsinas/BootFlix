namespace BootFlixBC7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetBirthdates : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Viewers SET BirthDate = '1988' WHERE Id = 1");
            Sql("UPDATE Viewers SET BirthDate = '1990' WHERE Id = 2");

        }
        
        public override void Down()
        {
        }
    }
}
