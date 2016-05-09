namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaidServiceFee_Changed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PaidServiceFees", "TotalFeeAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaidServiceFees", "TotalFeeAmount", c => c.Double(nullable: false));
        }
    }
}
