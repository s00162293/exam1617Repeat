using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models.students
{

    [Table("StudentSubject")]
    public class StudentSubject
    {

        [ForeignKey("associatedStudent")]
        public string StudentId { get; set; }

        [ForeignKey("associatedSubject")]
        public int SubjectId { get; set; }

        public virtual Student associatedStudent { get; set; }
        public virtual Subject associatedSubject { get; set; }
    }
}