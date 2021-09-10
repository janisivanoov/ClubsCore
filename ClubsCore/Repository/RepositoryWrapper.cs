using ClubsCore.Repository;
using Contracts;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IStudentRepository _student;
        private IClubRepository _club;

        public IStudentRepository student
        {
            get
            {
                if (_student == null)
                {
                    _student = new StudentRepository(_repoContext);
                }
                return _student;
            }
        }

        public IClubRepository club
        {
            get
            {
                if (_club == null)
                {
                    _club = new ClubRepository(_repoContext);
                }
                return _club;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}