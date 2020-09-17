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
    public class TeacherController : Controller
    {
        private ApplicationDatabase _context;

        public TeacherController(ApplicationDatabase context)
        {
            _context = context;
        }

        [HttpGet("GetTeacher")]
        public List<Teacher> GetTeacher()
        {
            try
            {

                var teacher = _context.Teachers.ToList();
                return teacher;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        [HttpGet("GetTeacherById/{TeacherID}")]
        public Teacher GetTeacherById(int TeacherID)
        {
            try
            {
                var teacher = _context.Teachers.FirstOrDefault(s => s.TeacherID == TeacherID);
                return teacher;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }


        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
           _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return CreatedAtAction("AddTeacher", new { id = teacher.TeacherID }, teacher);

        }

        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher([FromBody] Teacher teacher)
        {

            try
            {
                var selectedTeacher = _context.Teachers.FirstOrDefault(g => g.TeacherID == teacher.TeacherID);
                selectedTeacher.TeacherName = teacher.TeacherName;
                await _context.SaveChangesAsync();

                return CreatedAtAction("UpdateTeacher", selectedTeacher);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [HttpPost("DeleteTeacher/{TeacherID}")]
        public void DeleteTeacher(int TeacherID)
        {
            try
            {
                var teacher = _context.Teachers.FirstOrDefault(s => s.TeacherID == TeacherID);
                _context.Teachers.Remove(teacher);
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
