using NXS.Services.Abstract.XlsImport;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.Gdp
{
    public class GdpVariableDescriptions
    {
        public static IVariableDescription[] GetAllDescriptions()
        {
            return new IVariableDescription[] {
                new GdpVariable(),
                new PopulationVariable()
            };
        }
    }
}