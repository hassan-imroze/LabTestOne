namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaidServiceFees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ServiceFeeId = c.String(nullable: false, maxLength: 128),
                        TotalFeeAmount = c.Double(nullable: false),
                        PaidAmount = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceFees", t => t.ServiceFeeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ServiceFeeId);
            
            CreateTable(
                "dbo.ServiceFees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ServiceName = c.String(nullable: false),
                        ServicePrice = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false),
                        Roll = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaidServiceFees", "StudentId", "dbo.Students");
            DropForeignKey("dbo.PaidServiceFees", "ServiceFeeId", "dbo.ServiceFees");
            DropIndex("dbo.PaidServiceFees", new[] { "ServiceFeeId" });
            DropIndex("dbo.PaidServiceFees", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.ServiceFees");
            DropTable("dbo.PaidServiceFees");
        }
    }
}
