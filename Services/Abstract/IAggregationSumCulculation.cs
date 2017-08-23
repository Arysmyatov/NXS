using System.Threading.Tasks;

namespace NXS.Services.Abstract
{
    public interface IAggregationSumCulculation
    {
        Task UpdateSumsAsync();
    }
}