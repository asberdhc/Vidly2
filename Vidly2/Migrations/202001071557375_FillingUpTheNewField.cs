namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillingUpTheNewField : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET name = 'Buy expensive' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET name = 'Annualy' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
