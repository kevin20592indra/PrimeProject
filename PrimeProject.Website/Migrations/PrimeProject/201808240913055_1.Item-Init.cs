namespace PrimeProject.Website.Migrations.PrimeProject
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1ItemInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Guid(nullable: false),
                        ItemName = c.String(),
                        Type = c.String(),
                        Parameters = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}
