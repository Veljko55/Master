namespace AssetSCADA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScadaBreakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Boolean(nullable: false),
                        ModelCode = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        SimulatorAddress = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScadaBreakers");
        }
    }
}
