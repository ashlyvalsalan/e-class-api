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
    public class TutorialController : Controller
    {
        private ApplicationDatabase _context;
        private int SIZE = 32;
        public TutorialController(ApplicationDatabase context)
        {
            _context = context;
        }

        [HttpGet("GetTutorial")]
        public List<Tutorial> GetTutorial()
        {
            try
            {
                var tutorials = _context.Tutorials.ToList();
                return tutorials;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


        }
        [HttpGet("GetTutorialById/{TutorialID}")]
        public Tutorial GetTutorialById(int TutorialID)
        {
            try
            {
                var tutorial = _context.Tutorials.FirstOrDefault(s => s.TutorialID == TutorialID);
                return tutorial;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        /*
        [HttpGet]
        [Route("GetTutorialByAssignment/{AssignmentID}")]
        public Tutorial GetTutorialByAssignment(int AssignmentID)
        {
            try
            {
                var tutorial = _context.Tutorials.FirstOrDefault(s => s.AssignmentID == AssignmentID);
                return tutorial;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        */

        [HttpPost("AddTutorial")]
        public async Task<IActionResult> AddTutorial([FromBody] Tutorial tutorial)
        {
            
                _context.Tutorials.Add(tutorial);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AddTutorial", new { id = tutorial.TutorialID }, tutorial);
          
        }

        [HttpPut("UpdateTutorial")]
        public async Task<IActionResult> UpdateTutorial([FromBody] Tutorial tutorial)
        {

            try
            {
                var selectedTutorial = _context.Tutorials.FirstOrDefault(g => g.TutorialID == tutorial.TutorialID);
                selectedTutorial.TutorialLink = tutorial.TutorialLink;
               // selectedTutorial.AssignmentID = tutorial.AssignmentID;
                await _context.SaveChangesAsync();

                return CreatedAtAction("UpdateTutorial", selectedTutorial);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [HttpPost("DeleteTutorial/{TutorialID}")]
        public void DeleteTutorial(int TutorialID)
        {
            try
            {
                var tutorial = _context.Tutorials.FirstOrDefault(s => s.TutorialID == TutorialID);
                _context.Tutorials.Remove(tutorial);
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
