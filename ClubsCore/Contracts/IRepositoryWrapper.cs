namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IStudentRepository student { get; }
        IClubRepository club { get; }

        void Save();
    }
}