namespace SoccerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComplexTypePersonalInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jugadores", "PersonalInfo_Photo", c => c.String());
            AddColumn("dbo.Jugadores", "Altura", c => c.Decimal(precision: 20, scale: 4));
            AddColumn("dbo.Jugadores", "PersonalInfo_Nationality", c => c.String());
            AddColumn("dbo.Jugadores", "Direccion", c => c.String());
            AddColumn("dbo.Staffs", "PersonalInfo_Photo", c => c.String());
            AddColumn("dbo.Staffs", "Altura", c => c.Decimal(precision: 20, scale: 4));
            AddColumn("dbo.Staffs", "PersonalInfo_Nationality", c => c.String());
            AddColumn("dbo.Staffs", "Direccion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Direccion");
            DropColumn("dbo.Staffs", "PersonalInfo_Nationality");
            DropColumn("dbo.Staffs", "Altura");
            DropColumn("dbo.Staffs", "PersonalInfo_Photo");
            DropColumn("dbo.Jugadores", "Direccion");
            DropColumn("dbo.Jugadores", "PersonalInfo_Nationality");
            DropColumn("dbo.Jugadores", "Altura");
            DropColumn("dbo.Jugadores", "PersonalInfo_Photo");
        }
    }
}
