using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_class.Models
{
    public class Subject
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string TutorName { get; set; }
        public int TeacherID { get; set; }
      //  public ICollection<Teacher> Teachers { get; set; }
    }
}
