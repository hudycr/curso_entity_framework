namespace SoccerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFluentApiHerencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(),
                        DebutDate = c.DateTime(),
                        CountryName = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Speciality = c.String(),
                        Tipo = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
        }
    }
}
