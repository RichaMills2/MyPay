namespace MyPay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTaxTables : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into TaxTables (MinimumAmount,MaximumAmount,Amount,TaxAmount,Threshhold,TaxYearEnding) Values(0,18200,0,0,0,2018)");
            Sql("Insert Into TaxTables (MinimumAmount,MaximumAmount,Amount,TaxAmount,Threshhold,TaxYearEnding) Values(18201,37000,0,19,18200,2018)");
            Sql("Insert Into TaxTables (MinimumAmount,MaximumAmount,Amount,TaxAmount,Threshhold,TaxYearEnding) Values(37001,87000,3572,32.5,37000,2018)");
            Sql("Insert Into TaxTables (MinimumAmount,MaximumAmount,Amount,TaxAmount,Threshhold,TaxYearEnding) Values(87001,180000,19822,37,87000,2018)");
            Sql("Insert Into TaxTables (MinimumAmount,MaximumAmount,Amount,TaxAmount,Threshhold,TaxYearEnding) Values(180001,9999999,54232,45,180000,2018)");
        }
        
        public override void Down()
        {
        }
    }
}
