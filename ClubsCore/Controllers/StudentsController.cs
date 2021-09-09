using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClubsCore.Models;
using ClubsCore.Paging;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsCore.Controllers
{
    public class StudentsController : ApiControllerBase
    {
        public StudentsController(ClubsContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        //TODO: Add FilterForStudent

        /*
        [HttpGet]
        public IActionResult GetStudent([FromQuery] Student_Parameters studentParameters)
        {
            if (!studentParameters.ValidYearRange)
            {
                return BadRequest("Max year of birth cannot be less than min year of birth");
            }
            var students = _context.Students.GetStudent(studentParameters);   //?????????????
            var metadata = new
            {
                owners.TotalCount,
                owners.PageSize,
                owners.CurrentPage,
                owners.TotalPages,
                owners.HasNext,
                owners.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            _logger.LogInfo($"Returned {students.TotalCount} owners from database.");     //??????
            return Ok(students);
        }
        */

        //FILTER WHICH WORKS USING ONLY IDATAREPOSITORY:
        /*
        [HttpPost]
        [Route("GetAll")]
        public List<T> GetAll<T>(Student KeyDataForStudent)
        {
            return _repository.GetAll();
        }
        */

        /// <summary>
        /// GetAll
        /// </summary>
        [HttpGet]
        public IActionResult GetStudents([FromQuery] QueryParameters queryparameters)
        {
            var studentsQuery = _context.Students
                                     .OrderBy(c => c.Id);

            var students = Paginate<Student>(studentsQuery, queryparameters);

            return Ok(students);
        }

        public List<Student> Paginate<Student>(IOrderedQueryable<Student> query, QueryParameters queryparameters)
        {
            return query.ProjectTo<Student>(_mapper.ConfigurationProvider)
                                .Skip((queryparameters.PageNumber - 1) * queryparameters.PageSize)
                                .Take(queryparameters.PageSize)
                                .ToList();
        }

        /// <summary>
        /// Get_By_Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students
                               .Where(x => x.Id == id)
                               .ProjectTo<Student>(_mapper.ConfigurationProvider)
                               .FirstOrDefault();

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        /// <summary>
        /// Post
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostClubAsync(Student studentPost)
        {
            var post_student = _context.Students
                                    .Add(studentPost);

            await _context.SaveChangesAsync();
            return CreatedAtRoute("Post", new { Id = studentPost.Id }, studentPost);
        }

        /// <summary>
        /// Delete
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Students
                                     .FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        /// <summary>
        /// Patch
        /// </summary>
        [HttpPatch]
        public IActionResult JsonPatchWithModelState(
            [FromBody] JsonPatchDocument<Student> patchDoc)
        {
            if (patchDoc != null)
            {
                var student = CreateStudent();

                patchDoc.ApplyTo(student, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(student);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private Student CreateStudent()
        {
            return new Student
            {
                Id = 8,
                FirstName = "Example1",
                LastName = "Example2",
                BirthDate = new DateTime(2012, 12, 12)
            };
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}