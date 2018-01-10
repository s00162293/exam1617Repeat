using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models.students
{
    [Table("Lecturer")]
    public class Lecturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Lecturer ID")]
        public int LecturerId { get; set; }

        [Display(Name = "Lecturer Name")]
        public string LecturerName { get; set; }

        public virtual ICollection<StudentSubject> lecturerInLecturerSubject { get; set; }



    }
}