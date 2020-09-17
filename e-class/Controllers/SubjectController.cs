using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_class.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_class.Controllers
{
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
        private ApplicationDatabase _context;

        public SubjectController(ApplicationDatabase context)
        {
            _context = context;
        }

        [HttpGet("GetSubject")]
        public List<Subject> GetSubject( )
        {
            try
            {
             
                var subject = _context.Subjects.ToList();
                return subject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        [HttpGet("GetSubjectById/{SubjectID}")]
        public Subject GetSubjectById(int SubjectID)
        {
            try
            {
                var subject = _context.Subjects.FirstOrDefault(s=>s.SubjectID == SubjectID);
                return subject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        /*
        [HttpGet]
        [Route("GetSubjectByStudent/{StudentID}")]
        public List<Subject> GetSubjectByStudentID(int StudentID)
        {
            try
            {
                var subject = _context.Subjects.Where(s => s.StudentID == StudentID).ToList();
                return subject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        

        [HttpGet]
        [Route("GetSubjectByTeacher/{TeacherID}")]
        public List<Subject> GetSubjectByTeacher(int TeacherID)
        {
            try
            {
                var subject = _context.Subjects.Where(s => s.TeacherID == TeacherID).ToList();
                return subject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        */

        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] Subject subject)
        {
            
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AddSubject", new { id = subject.SubjectID }, subject);
          
        }

        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject([FromBody] Subject subject)
        {

            try
            {
                var selectedSubject = _context.Subjects.FirstOrDefault(g => g.SubjectID == subject.SubjectID);
                selectedSubject.SubjectName = subject.SubjectName;
                selectedSubject.TutorName = subject.TutorName;
               // selectedSubject.SubjectID = subject.SubjectID;
                //selectedSubject.TeacherID = subject.TeacherID;


                await _context.SaveChangesAsync();

                return CreatedAtAction("UpdateSubject", selectedSubject);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [HttpPost("DeleteSubject/{SubjectID}")]
        public void DeleteSubject(int SubjectID)
        {
            try
            {
                var subject = _context.Subjects.FirstOrDefault(s => s.SubjectID == SubjectID);
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

        }

    }
}
