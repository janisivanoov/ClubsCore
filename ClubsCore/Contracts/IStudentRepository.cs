using ClubsCore.Models;
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
    }
}