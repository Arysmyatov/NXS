using NXS.Services.Abstract.XlsImport;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class WorldVariableDescriptions
    {
        public static IVariableDescription[] GetAllDescriptions()
        {
            return new IVariableDescription[] {
                new PrimaryEnergyImpExportDescription()
            };
        }
    }
}