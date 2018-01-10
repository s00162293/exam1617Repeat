using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models
{
    [Table("LecturerSubject")]
    public class LecturerSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "LecturerSubject ID")]
        public int lectureSubjectId { get; set; }

        [ForeignKey("associatedSubject")]
        public int SubjectId { get; set; }


        [ForeignKey("associatedLecturer")]
        public int LecturerId { get; set; }

        public virtual Subject associatedSubject { get; set; }
        public virtual Lecturer associatedLecturer { get; set; }
    }
}