using NXS.Services.Abstract.XlsFormulaUpdater;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableDescriptions
{
    public static class XlsVariableDescriptions
    {
        private static IXlsVariableDescription ElectrcityGenerationVariableDescription = new ElectrcityGenerationVariableDescription();
        private static IXlsVariableDescription ElectricityConsumptionBySectorVariableDescription = new ElectricityConsumptionBySectorVariableDescription();
        private static IXlsVariableDescription ElectricCapacityVariableDescription = new ElectricCapacityVariableDescription();
        private static IXlsVariableDescription ElectricCapacityAdditionsVariableDescription = new ElectricCapacityAdditionsVariableDescription();
        private static IXlsVariableDescription PrimaryEnergySupplyVariableDescription = new PrimaryEnergySupplyVariableDescription();
        private static IXlsVariableDescription PjVariableDescription = new PjVariableDescription();
        private static IXlsVariableDescription FinalEnergyConsumptionByFuelVariableDescription = new FinalEnergyConsumptionByFuelVariableDescription();
        private static IXlsVariableDescription FinalEnergyConsumptionBySectorVariableDescription = new FinalEnergyConsumptionBySectorVariableDescription();
        private static IXlsVariableDescription Co2EmissionBySectorVariableDescription = new Co2EmissionBySectorVariableDescription();
        private static IXlsVariableDescription TradeImportVariableDescription = new TradeImportVariableDescription();
        private static IXlsVariableDescription TradeInExportVariableDescription = new TradeInExportVariableDescription();
        private static IXlsVariableDescription TransportDemandByFuelTypeVariableDescription = new TransportDemandByFuelTypeVariableDescription();
        private static IXlsVariableDescription IndustryConsumptionByEndUseSectorsVariableDescription = new IndustryConsumptionByEndUseSectorsVariableDescription();

        public static IXlsVariableDescription[] AllDescriptions
        {
            get => new IXlsVariableDescription[] {
                ElectrcityGenerationVariableDescription,
                ElectricityConsumptionBySectorVariableDescription,
                ElectricCapacityVariableDescription,
                ElectricCapacityAdditionsVariableDescription,
                PrimaryEnergySupplyVariableDescription,
                PjVariableDescription,
                FinalEnergyConsumptionByFuelVariableDescription,
                FinalEnergyConsumptionBySectorVariableDescription,
                // Co2EmissionBySectorVariableDescription
                TradeImportVariableDescription,
                TradeInExportVariableDescription,
                // TransportDemandVariableDescription
                TransportDemandByFuelTypeVariableDescription,
                IndustryConsumptionByEndUseSectorsVariableDescription
            };
        }
    }
}