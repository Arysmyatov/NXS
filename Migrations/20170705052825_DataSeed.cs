using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // KeyParameters
            // Coal
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2010', " + 
                "10576)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2015', " + 
                "8761)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2020', " + 
                "8619)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2025', " + 
                "8732)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2030', " + 
                "9032)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2035', " + 
                "8706)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2040', " + 
                "8616)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2045', " + 
                "8092)");
            migrationBuilder.Sql("INSERT INTO Data (RegionId, ScenarioId, VariableId, KeyParameterId, KeyParameterLevelId, Year, Value) VALUES (" +
                "(SELECT ID FROM Regions WHERE Name = 'UKI'), " +
                "(SELECT ID FROM Scenarios WHERE Name = 'Low Carbon'), " +
                "(SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy')), " +
                "(SELECT ID FROM KeyParameters WHERE Name = 'Coal' AND KeyParameterGroupId = (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices')), " +
                "(SELECT ID FROM KeyParameterLevels WHERE Name = 'Low'), " +
                "'2050', " + 
                "7317)");       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}