namespace examRepeat1617.Migrations.AttendDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigrationsattend : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        AttendanceDate = c.DateTime(nullable: false),
                        Present = c.Boolean(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentSubject",
                c => new
                    {
                        studentSubjectId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        SubjectId = c.Int(nullable: false),
                        Lecturer_LecturerId = c.Int(),
                    })
                .PrimaryKey(t => t.studentSubjectId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Lecturer", t => t.Lecturer_LecturerId)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId)
                .Index(t => t.Lecturer_LecturerId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lecturer",
                c => new
                    {
                        LecturerId = c.Int(nullable: false, identity: true),
                        LecturerName = c.String(),
                    })
                .PrimaryKey(t => t.LecturerId);
            
            CreateTable(
                "dbo.LecturerSubject",
                c => new
                    {
                        lectureSubjectId = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        LecturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lectureSubjectId)
                .ForeignKey("dbo.Lecturer", t => t.LecturerId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.LecturerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LecturerSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.LecturerSubject", "LecturerId", "dbo.Lecturer");
            DropForeignKey("dbo.StudentSubject", "Lecturer_LecturerId", "dbo.Lecturer");
            DropForeignKey("dbo.Attendances", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Attendances", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentSubject", "StudentId", "dbo.Student");
            DropIndex("dbo.LecturerSubject", new[] { "LecturerId" });
            DropIndex("dbo.LecturerSubject", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubject", new[] { "Lecturer_LecturerId" });
            DropIndex("dbo.StudentSubject", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubject", new[] { "StudentId" });
            DropIndex("dbo.Attendances", new[] { "SubjectId" });
            DropIndex("dbo.Attendances", new[] { "StudentId" });
            DropTable("dbo.LecturerSubject");
            DropTable("dbo.Lecturer");
            DropTable("dbo.Subject");
            DropTable("dbo.StudentSubject");
            DropTable("dbo.Student");
            DropTable("dbo.Attendances");
        }
    }
}
