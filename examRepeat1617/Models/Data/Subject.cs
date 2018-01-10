using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models
{
     [Table("Subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Subject ID")]
        public int SubjectId { get; set; }

        [Display(Name = "Subject Name")]
        public int SubjectName { get; set; }

        public virtual ICollection<StudentSubject> subjectInStudentSubject { get; set; }




    }
}