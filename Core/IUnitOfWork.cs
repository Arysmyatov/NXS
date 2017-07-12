using System;
using System.Threading.Tasks;

namespace NXS.Core
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}