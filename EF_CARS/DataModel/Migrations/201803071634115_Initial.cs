namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Producer = c.String(),
                        Model = c.String(),
                        HighSpeed = c.Int(nullable: false),
                        BodyType = c.String(),
                        CarEngine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Engines", t => t.CarEngine_Id)
                .Index(t => t.CarEngine_Id);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cylinders = c.Int(nullable: false),
                        Power = c.Int(nullable: false),
                        Liters = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarEngine_Id", "dbo.Engines");
            DropIndex("dbo.Cars", new[] { "CarEngine_Id" });
            DropTable("dbo.Engines");
            DropTable("dbo.Cars");
        }
    }
}
