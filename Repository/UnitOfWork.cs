using System.Threading.Tasks;
using Udemy.Context;

namespace Udemy.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UdemyContext context;
        public UnitOfWork(UdemyContext context)
        {
            this.context = context;

        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}