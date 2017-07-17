using System.Collections.Generic;
using NXS.Core.Models;

namespace NXS.Services.Strategies
{
    public abstract class ExportStategyAbstastract
    {
        internal const string ByRegionSheetName = "By region";
        internal const string GlobalResultsSheetName = "Global Results";
        internal const string GeneralParametersSheetName = "General parameters";


        public abstract IEnumerable<Data> GetDataFromXls();
    }
}