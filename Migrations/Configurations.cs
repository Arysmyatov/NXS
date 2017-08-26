using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NXS.Core.Models;
using NXS.Persistence;

namespace NXS.Migrations
{
    public static class DbInitializer
    {
        static private NxsDbContext _context;

        public async static void InitializeAync(NxsDbContext context)
        {
            _context = context;

            await _context.Database.EnsureCreatedAsync();
            await InitializeAgreegationSubVariableAync();
        }


        private async static Task InitializeAgreegationSubVariableAync()
        {
            if (_context.AgreegationSubVariables.Any())
            {
                return;   // exit method, InitializeAgreegation has been seeded
            }

            if (!_context.Variables.Any())
            {
                return;   // exit method if no variables
            }

            // Generate for Generation Variable 
            var electricityVariableGroup = _context.VariableGroups.Include(v => v.Variables).SingleOrDefault(v => v.Name == "Electricity");
            var generationVariable = electricityVariableGroup.Variables.SingleOrDefault(v => v.Name == "Generation");

            await SeedGenerateSolar(generationVariable);
            await SeedGenerateWind(generationVariable);

            // Consumption by sector Variable
            var consumptionBySectorVariable = electricityVariableGroup.Variables.SingleOrDefault(v => v.Name == "Consumption by sector");
            await SeedConsumptionBySectorTransport(consumptionBySectorVariable);

            // Electric Capacity
            var electricCapacityVariable = electricityVariableGroup.Variables.SingleOrDefault(v => v.Name == "Capacity");
            await SeedElectricCapacitySolar(electricCapacityVariable);
            await SeedElectricCapacityWind(electricCapacityVariable);

            // Final Energy Consumption Variable 
            var finalEnergyConsumptionVariableGroup = _context.VariableGroups.Include(v => v.Variables).SingleOrDefault(v => v.Name == "Final Energy Consumption");
            var byFuelVariable = finalEnergyConsumptionVariableGroup.Variables.SingleOrDefault(v => v.Name == "Final Energy Consumption : By fuel");
            await SeedFinalEnergyConsumptionFuelOilProducts(byFuelVariable);
        }

        #region private Methods

        private static async Task SeedGenerateSolar(Variable generationVariable)
        {
            var solarVariable = new AgreegationSubVariable
            {
                Name = "Solar",
                VariableId = generationVariable.Id
            };

            await _context.AgreegationSubVariables.AddAsync(solarVariable);
            await _context.SaveChangesAsync();

            // Solar PV
            var SolarPVSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Solar PV",
                AgreegationSubVariableId = solarVariable.Id
            };

            // Solar thermal        
            var SolarThermalVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Solar thermal",
                AgreegationSubVariableId = solarVariable.Id
            };
            await _context.AgreegationSubVariableSubVariables.AddAsync(SolarPVSubVariable);
            await _context.AgreegationSubVariableSubVariables.AddAsync(SolarThermalVariable);
            await _context.SaveChangesAsync();
        }


        private static async Task SeedGenerateWind(Variable generationVariable)
        {
            var windVariable = new AgreegationSubVariable
            {
                Name = "Wind",
                VariableId = generationVariable.Id
            };

            await _context.AgreegationSubVariables.AddAsync(windVariable);
            await _context.SaveChangesAsync();

            // Offshore
            var OffshoreSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Offshore",
                AgreegationSubVariableId = windVariable.Id
            };

            // Onshore     
            var OnshoreSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Onshore",
                AgreegationSubVariableId = windVariable.Id
            };
            await _context.AgreegationSubVariableSubVariables.AddAsync(OffshoreSubVariable);
            await _context.AgreegationSubVariableSubVariables.AddAsync(OnshoreSubVariable);
            await _context.SaveChangesAsync();            
        }        


        private static async Task SeedConsumptionBySectorTransport(Variable consumptionBySectorVariable)
        {
            var transportVariable = new AgreegationSubVariable
            {
                Name = "Transport",
                VariableId = consumptionBySectorVariable.Id
            };

            await _context.AgreegationSubVariables.AddAsync(transportVariable);
            await _context.SaveChangesAsync();

            // Transport - surface
            var transportSurfaceSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Transport - surface",
                AgreegationSubVariableId = transportVariable.Id
            };

            // Transport - ships
            var transportShipsSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Transport - ships",
                AgreegationSubVariableId = transportVariable.Id
            };

            // Transport - aviation
            var transportAviationSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Transport - aviation",
                AgreegationSubVariableId = transportVariable.Id
            };

            await _context.AgreegationSubVariableSubVariables.AddAsync(transportSurfaceSubVariable);
            await _context.AgreegationSubVariableSubVariables.AddAsync(transportShipsSubVariable);
            await _context.AgreegationSubVariableSubVariables.AddAsync(transportAviationSubVariable);
            await _context.SaveChangesAsync();
        }
        

        private static async Task SeedElectricCapacitySolar(Variable electricCapacityVariable)
        {

            var solarVariable = new AgreegationSubVariable
            {
                Name = "Solar",
                VariableId = electricCapacityVariable.Id
            };

            await _context.AgreegationSubVariables.AddAsync(solarVariable);
            await _context.SaveChangesAsync();

            // Solar PV
            var solarpVSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Solar PV",
                AgreegationSubVariableId = solarVariable.Id
            };

            // Solar thermal
            var SolarThermalSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Solar thermal",
                AgreegationSubVariableId = solarVariable.Id
            };

            await _context.AgreegationSubVariableSubVariables.AddAsync(solarpVSubVariable);
            await _context.AgreegationSubVariableSubVariables.AddAsync(SolarThermalSubVariable);
            await _context.SaveChangesAsync();
        }


        private static async Task SeedElectricCapacityWind(Variable electricCapacityVariable)
        {
            var windVariable = new AgreegationSubVariable
            {
                Name = "Wind",
                VariableId = electricCapacityVariable.Id
            };

            await _context.AgreegationSubVariables.AddAsync(windVariable);
            await _context.SaveChangesAsync();

            // Offshore
            var offshoreSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Offshore",
                AgreegationSubVariableId = windVariable.Id
            };

            // Onshore
            var onshoreSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Onshore",
                AgreegationSubVariableId = windVariable.Id
            };
            
            // Solar PV
            // var ___ SubVariable = new AgreegationSubVariableSubVariable
            // {
            //     Name = "______",
            //     AgreegationSubVariableId = transportVariable.Id
            // };

            await _context.AgreegationSubVariableSubVariables.AddAsync(offshoreSubVariable);
            await _context.AgreegationSubVariableSubVariables.AddAsync(onshoreSubVariable);
            await _context.SaveChangesAsync();
        }         


        private static async Task SeedFinalEnergyConsumptionFuelOilProducts(Variable byFuelVariable)
        {
            var oilProductsVariable = new AgreegationSubVariable
            {
                Name = "Oil Products",
                VariableId = byFuelVariable.Id
            };

            await _context.AgreegationSubVariables.AddAsync(oilProductsVariable);
            await _context.SaveChangesAsync();

            // Hydrocarbons
            var hydrocarbonsSubVariable = new AgreegationSubVariableSubVariable
            {
                Name = "Hydrocarbons",
                AgreegationSubVariableId = oilProductsVariable.Id
            };
            
            await _context.AgreegationSubVariableSubVariables.AddAsync(hydrocarbonsSubVariable);
            await _context.SaveChangesAsync();            
        }        

        #endregion private
    }
}