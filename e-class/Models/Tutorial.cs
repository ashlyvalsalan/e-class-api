using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_class.Models
{
    public class Tutorial
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TutorialID { get; set; }
        public string TutorialLink { get; set; }
        public int AssignmentID { get; set; }
       // public ICollection<Assignment> Assignments { get; set; }

    }
}
