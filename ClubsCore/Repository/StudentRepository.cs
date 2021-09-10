using ClubsCore.Models;
using ClubsCore.Paging;
using ClubsCore.Parameters;
using ClubsCore.Repository;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Student> GetAllstudents()
        {
            return FindAll()
                .OrderBy(ow => ow.FirstName)
                .ToList();
        }

        public Student GetstudentById(int studentId)
        {
            return FindByCondition(student => student.Id.Equals(studentId))
                .FirstOrDefault();
        }

        public Student GetstudentWithDetails(int studentId)
        {
            return FindByCondition(student => student.Id.Equals(studentId))
                .Include(ac => ac.Club)
                .FirstOrDefault();
        }

        public void Createstudent(Student student)
        {
            Create(student);
        }

        public void Updatestudent(Student student)
        {
            Update(student);
        }

        public void Deletestudent(Student student)
        {
            Delete(student);
        }

        public PagedList<Student> GetStudents(StudentParameters studentParameters)
        {
            var owners = FindByCondition(o => o.BirthDate.Year >= studentParameters.MinYearOfBirth &&
                                        o.BirthDate.Year <= studentParameters.MaxYearOfBirth)
                                    .OrderBy(on => on.FirstName);
            return PagedList<Student>.ToPagedList(owners,
                studentParameters.PageNumber,
                studentParameters.PageSize);
        }
    }
}