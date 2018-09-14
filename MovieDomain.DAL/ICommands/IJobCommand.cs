using MovieDomain.Entities;

namespace MovieDomain.DAL.ICommands
{
    public interface IJobCommand : ICommand<Job, int>
    {
    }
}
