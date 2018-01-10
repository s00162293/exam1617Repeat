using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models.students
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Attendance ID")]
        public int AttendanceId { get; set; }

        [Display(Name = "Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [Display(Name = "Present")]
        public bool Present { get; set; }

        [ForeignKey("associatedStudent")]
        public string StudentId { get; set; }

        [ForeignKey("associatedSubject")]
        public int SubjectId { get; set; }

        public virtual Student associatedStudent { get; set; }
        public virtual Subject associatedSubject { get; set; }

    }
}