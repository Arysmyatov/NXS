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
                new FinalEnergyConsumptionByFuelDescription(),
                new FinalEnergyConsumptionBySectorlDescription(),
                new ElectricityGenerationDescription(),
                new ElectricityCo2IntensityDescription(),
                new ElectricityConsumptionBySectorDescription(),
                new ElectricityCapacityDescription(),
                new ElectricityAnnualisedInvestmentCostsDescription(),
                new EmissionesCo2EmissionsBySectorDescription(),
                // new EmissionesNonCo2EmissionsBySectorDescription(),
                // new EmissionesCo2EmissionsByRegionDescription(),
                new TransportFuelConsumptionByTechnologyDescription(),
                new IndustryFuelConsumptionByTechnologyDescription(),
                new ResidentialFuelConsumptionByTechnologyDescription(),
                new CommercialFuelConsumptionByTechnologyDescription(),
                new AgricultureFuelConsumptionByTechnologyDescription()
            };
        }
    }
}