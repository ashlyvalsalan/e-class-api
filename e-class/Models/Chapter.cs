using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_class.Models
{
    public class Chapter
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ChapterID { get; set; }
        public string ChapterName { get; set; }
        public int SubjectID { get; set; }
        //public ICollection<Subject> Subjects { get; set; }
    }
}
