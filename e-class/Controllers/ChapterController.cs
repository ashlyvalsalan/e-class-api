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
    public class ChapterController : Controller
    {
        private ApplicationDatabase _context;
        private int SIZE = 32;
        public ChapterController(ApplicationDatabase context)
        {
            _context = context;
        }
        [HttpGet("GetChapter")]
        public List<Chapter> GetChapter()
        {
            try
            {
                var chapters = _context.Chapters.ToList();
                return chapters;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
        [HttpGet("GetChapterById/{ChapterID}")]
        public Chapter GetChapterById(int ChapterID)
        {
            try
            {
                var chapter = _context.Chapters.FirstOrDefault(s => s.ChapterID == ChapterID);
                return chapter;
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
        [HttpPost("AddChapter")]
        public async Task<IActionResult> AddChapter([FromBody] Chapter chapter)
        {
            
                
                _context.Chapters.Add(chapter);
                await _context.SaveChangesAsync();

                return CreatedAtAction("AddChapter", new { id = chapter.ChapterID }, chapter);
           
        }

        [HttpPut("UpdateChapter")]
        public async Task<IActionResult> UpdateChapter([FromBody] Chapter chapter)
        {
            try
            {
                var selectedChapter = _context.Chapters.FirstOrDefault(g => g.ChapterID == chapter.ChapterID);
                selectedChapter.ChapterName = chapter.ChapterName;
               // selectedChapter.SubjectID = chapter.SubjectID;
                

                await _context.SaveChangesAsync();

                return CreatedAtAction("updateGenre", selectedChapter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [HttpPost("DeleteChapter/{ChapterID}")]
        public void DeleteChapter(int ChapterID)
        {
            try
            {
                var chapter = _context.Chapters.FirstOrDefault(s => s.ChapterID == ChapterID);
                _context.Chapters.Remove(chapter);
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
