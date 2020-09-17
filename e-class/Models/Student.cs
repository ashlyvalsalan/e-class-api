using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_class.Models
{
    public class Student
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int SubjectID1 { get; set; }
        public int SubjectID2 { get; set; }
        public int SubjectID3 { get; set; }
        public int SubjectID4 { get; set; }


    }
}


