﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace examRepeat1617.Models
{

    [Table("StudentSubject")]
    public class StudentSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "StudentSubject ID")]
        public int studentSubjectId { get; set; }

        [ForeignKey("associatedStudent")]
        public string StudentId { get; set; }

        [ForeignKey("associatedSubject")]
        public int SubjectId { get; set; }

        public virtual Student associatedStudent { get; set; }
        public virtual Subject associatedSubject { get; set; }
    }
}