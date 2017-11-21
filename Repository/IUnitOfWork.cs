using System.Threading.Tasks;

namespace Udemy.Repository
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}