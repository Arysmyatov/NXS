using NXS.Services.Abstract.XlsImport;

namespace NXS.Services.Excel.DataImport.VariableDescriptions.WorldRegion
{
    public class WorldVariableDescriptions
    {
        public static IVariableDescription[] GetAllDescriptions()
        {
            return new IVariableDescription[] {
                new PrimaryEnergyImpExportDescription(),
                new FinalEnergyConsumptionByFuelDescription(),
                new FinalEnergyConsumptionBySectorlDescription(),
                new ElectricityGenerationDescription(),
                new ElectricityCo2IntensityDescription(),
                new ElectricityConsumptionBySectorDescription(),
                new ElectricityCapacityDescription(),
                new ElectricityAnnualisedInvestmentCostsDescription(),
                new EmissionesCo2EmissionsBySectorDescription(),
                new TransportFuelConsumptionByTechnologyDescription(),
                new IndustryFuelConsumptionByTechnologyDescription(),
                new ResidentialFuelConsumptionByTechnologyDescription(),
                new CommercialFuelConsumptionByTechnologyDescription(),
                new AgricultureFuelConsumptionByTechnologyDescription()
            };
        }
    }
}