namespace examRepeat1617.Migrations.ApplicationUsers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolesadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "studentId", c => c.String());
            AddColumn("dbo.AspNetUsers", "lecturerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "lecturerId");
            DropColumn("dbo.AspNetUsers", "studentId");
        }
    }
}
