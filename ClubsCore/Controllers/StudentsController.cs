using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClubsCore.Contracts;
using ClubsCore.Models;
using ClubsCore.Paging;
using ClubsCore.Parameters;
using Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubsCore.Controllers
{
    public class StudentsController : ApiControllerBase
    {
        public StudentsController(ClubsContext context, IMapper mapper, ILoggerManager logger, IRepositoryWrapper repository)
            : base(context, mapper, logger, repository)
        {
        }

        /// <summary>
        /// Filter
        /// </summary>
        //To try use /api/owner?maxYearOfBirth=1997
        [HttpGet]
        public IActionResult GetStudent([FromQuery] StudentParameters studentParameters)
        {
            if (false == studentParameters.IsValidYearRange)
            {
                return BadRequest("Max year of birth cannot be less than min year of birth");
            }
            var students = _repository.student.GetStudents(studentParameters);
            var meta = new
            {
                students.PageSize,
                students.CurrentPage,
                students.TotalPages
            };
            var entries = new
            {
                students.TotalCount,
                students.HasNext,
                students.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(meta));
            _logger.LogInfo($"Returned {students.TotalCount} owners from database.");
            return Ok(students);
        }

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