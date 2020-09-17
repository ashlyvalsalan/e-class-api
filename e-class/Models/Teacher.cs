using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_class.Models
{
    public class Teacher
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        //public string TutorName { get; set; }
        //public int SubjectID { get; set; }
        //public ICollection<Subject> Subjects{ get; set; }
    }
}
