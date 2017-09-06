using NXS.Services.Abstract.XlsImport;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.General
{
    public static class GeneralVariableDescriptions
    {
        public static IVariableDescription[] GetAllDescriptions()
        {
            return new IVariableDescription[] {
                // new PrimaryEnergyProductionDescription(),
                new PrimaryEnergyImpExportDescription(),
                new FinalEnergyConsumptionByFuelDescription()
            };
        }
    }
}