using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace e_class.Models
{
    public class Assignment
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AssignmentlID { get; set; }
        public string AssignmentName { get; set; }
        public DateTime DueDate { get; set; }
        public int ChapterID { get; set; }
       // public ICollection<Chapter> Chapters { get; set; }
    }
}

