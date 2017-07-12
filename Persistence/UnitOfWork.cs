using System.Threading.Tasks;
using NXS.Core; 

namespace NXS.Persistence
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly NxsDbContext context;

    public UnitOfWork(NxsDbContext context)
    {
      this.context = context;
    }

    public async Task CompleteAsync()
    {
      await context.SaveChangesAsync();
    }
  }
}