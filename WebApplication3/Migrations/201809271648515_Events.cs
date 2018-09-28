namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Events : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "GodzinaRozpoczeciaImprezy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "GodzinaRozpoczeciaImprezy", c => c.DateTime(nullable: false));
        }
    }
}
