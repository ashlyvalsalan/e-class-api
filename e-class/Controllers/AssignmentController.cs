using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_class.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_class.Controllers
{
    [Route("api/[controller]")]
    public class AssignmentController : Controller
    {
        private ApplicationDatabase _context;
        private int SIZE = 32;
        public AssignmentController(ApplicationDatabase context)
        {
            _context = context;
        }

        [HttpGet("GetAssignment")]
        public List<Assignment> GetAssignment()
        {
            try
            {
                var assignments = _context.Assignments.OrderBy(m => m.DueDate).ToList();
                return assignments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            

        }
        [HttpGet("GetAssignmentById/{AssignmentID}")]
        public Assignment GetAssignmentById(int AssignmentID)
        {
            try
            {
                var assignment = _context.Assignments.FirstOrDefault(s => s.AssignmentlID == AssignmentID);
                return assignment;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        /*
        [HttpGet]
        [Route("GetAssignmentByChapter/{ChapterID}")]
        public Assignment GetAssignmentByChapter(int ChapterID)
        {
            try
            {
                var assignment = _context.Assignments.FirstOrDefault(s => s.ChapterID == ChapterID);
                return assignment;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        */
        [HttpPost("AddAssignment")]
        public async Task<IActionResult> AddAssignment([FromBody] Assignment assignment)
        {
            
               
                _context.Assignments.Add(assignment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AddAssignment", new { id = assignment.AssignmentlID }, assignment);
          
        }

        [HttpPut("UpdateAssignment")]
        public async Task<IActionResult> UpdateAssignment([FromBody] Assignment assignment)
        {
            try
            {
                var selectedAssignment = _context.Assignments.FirstOrDefault(f => f.AssignmentlID == assignment.AssignmentlID);

                selectedAssignment.AssignmentName = assignment.AssignmentName;
                selectedAssignment.DueDate = assignment.DueDate;
               // selectedAssignment.ChapterID = assignment.ChapterID;

                await _context.SaveChangesAsync();

                return CreatedAtAction("UpdateAssignment", selectedAssignment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [HttpPost("DeleteAssignment/{AssignmentID}")]
        public void DeleteAssignment(int AssignmentID)
        {
            try
            {
                var assignment = _context.Assignments.FirstOrDefault(s => s.AssignmentlID == AssignmentID);
                _context.Assignments.Remove(assignment);
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
