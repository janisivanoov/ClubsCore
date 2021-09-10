using ClubsCore.Models;
using ClubsCore.Paging;
using ClubsCore.Parameters;
using System.Collections.Generic;

namespace Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllstudents();

        Student GetstudentById(int studentId);

        Student GetstudentWithDetails(int studentId);

        void Createstudent(Student student);

        void Updatestudent(Student student);

        void Deletestudent(Student student);

        public PagedList<Student> GetStudents(StudentParameters studentParameters);
    }
}