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
        private static IXlsVariableDescription ElcHeatIndelcVariableDescription = new ElcHeatIndelcVariableDescription();
        private static IXlsVariableDescription AgricultureFuelConsumptionByTechnologyDescriptionVariableDescription = new AgricultureFuelConsumptionByTechnologyDescriptionVariableDescription();
        private static IXlsVariableDescription CommercialFuelConsumptionByTechnologyDescriptionVariableDescription = new CommercialFuelConsumptionByTechnologyDescriptionVariableDescription();
        private static IXlsVariableDescription ResidentialFuelConsumptionByTechnologyDescriptionVariableDescription = new ResidentialFuelConsumptionByTechnologyDescriptionVariableDescription();
        private static IXlsVariableDescription Co2EmissionBySectorC_A03aVariableDescription = new Co2EmissionBySectorC_A03aVariableDescription();
        private static IXlsVariableDescription Co2EmissionBySectorC_A3bVariableDescription = new Co2EmissionBySectorC_A3bVariableDescription();
        private static IXlsVariableDescription Co2EmissionBySectorC_A3cVariableDescription = new Co2EmissionBySectorC_A3cVariableDescription();
        private static IXlsVariableDescription Co2EmissionBySectorC_A08dVariableDescription = new Co2EmissionBySectorC_A08dVariableDescription();

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
                IndustryConsumptionByEndUseSectorsVariableDescription,
                ElcHeatIndelcVariableDescription,
                AgricultureFuelConsumptionByTechnologyDescriptionVariableDescription,
                CommercialFuelConsumptionByTechnologyDescriptionVariableDescription,
                ResidentialFuelConsumptionByTechnologyDescriptionVariableDescription,
                Co2EmissionBySectorC_A03aVariableDescription,
                Co2EmissionBySectorC_A3bVariableDescription,
                Co2EmissionBySectorC_A3cVariableDescription,
                Co2EmissionBySectorC_A08dVariableDescription
            };
        }
    }
}