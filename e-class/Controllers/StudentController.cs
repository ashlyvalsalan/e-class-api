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
    public class StudentController : Controller
    {
        private ApplicationDatabase _context;

        public StudentController(ApplicationDatabase context)
        {
            _context = context;
        }
        [HttpGet("GetStudent")]
       
        public List<Student> GetStudent()
        {
            try
            {
                var students = _context.Students.ToList();
                return students;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        [HttpGet("GetStudent/{StudentID}")]
        public Student GetStudent(int StudentID)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(s => s.StudentID == StudentID);
                return student;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        /*
        
        [HttpGet]
        [Route("GetChapterBySubject/{SubjectID}")]
        public Chapter GetChapterBySubjectID(int SubjectID)
        {
            try
            {
                var chapter = _context.Chapters.FirstOrDefault(s => s.SubjectID == SubjectID);
                return chapter;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        */
        // [HttpPost]
        // [Route("AddStudent")]
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AddStudent", new { id = student.StudentID }, student);
            
        }

       [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {

            try
            {
                var selectedStudent = _context.Students.FirstOrDefault(g => g.StudentID == student.StudentID);
                selectedStudent.FirstName = student.FirstName;
                selectedStudent.LastName = student.LastName;
                selectedStudent.Email = student.Email;
                selectedStudent.Password = student.Password;


                await _context.SaveChangesAsync();

                return CreatedAtAction("UpdateStudent", selectedStudent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [HttpPost("DeleteStudent/{StudentID}")]
        public void DeleteStudent(int StudentID)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(s => s.StudentID == StudentID);
                _context.Students.Remove(student);
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
