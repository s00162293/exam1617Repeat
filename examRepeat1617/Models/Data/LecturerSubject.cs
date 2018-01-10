using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models
{
    [Table("LecturerSubject")]
    public class LecturerSubject
    {

        [ForeignKey("associatedSubject")]
        public int SubjectId { get; set; }


        [ForeignKey("associatedLecturer")]
        public int LecturerId { get; set; }

        public virtual Subject associatedSubject { get; set; }
        public virtual Student associatedLecturer { get; set; }
    }
}