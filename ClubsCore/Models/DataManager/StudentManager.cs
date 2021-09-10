using ClubsCore.Models.Repository;
using ClubsCore.Paging;
using System.Collections.Generic;
using System.Linq;

namespace ClubsCore.Models.DataManager
{
    public class StudentManager : IDataRepository<Student>
    {
        private ClubsContext _clubsContext;

        public StudentManager(ClubsContext context)
        {
            _clubsContext = context;
        }

        public IEnumerable<Student> GetAll(QueryParameters queryparameters)
        {
            return _clubsContext.Students.OrderBy(c => c.Id).Skip((queryparameters.PageNumber - 1) * queryparameters.PageSize).Take(queryparameters.PageSize).ToList();
        }

        public Student Get(long id)
        {
            return _clubsContext.Students
                  .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Student entity)
        {
            _clubsContext.Students.Add(entity);
            _clubsContext.SaveChanges();
        }

        public void Update(Student student, Student entity)
        {
            student.FirstName = entity.FirstName;
            student.LastName = entity.LastName;
            student.BirthDate = entity.BirthDate;
            student.Password = entity.Password;

            _clubsContext.SaveChanges();
        }

        public void Delete(Student student)
        {
            _clubsContext.Students.Remove(student);
            _clubsContext.SaveChanges();
        }
    }
}