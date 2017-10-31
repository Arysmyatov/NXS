using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NXS.Core;
using NXS.Core.Constants;
using NXS.Core.Models;

namespace NXS.Persistence
{
    public class SubVariableDailyDataRepository : ISubVariableDailyDataRepository
    {
        private const int ParentRegionId = 1;
        private const int RegionAgrigationTypeId = 1;
        private const int ScenarioId = 1;
        private const int VariableId = 23;
        private const int KeyParameterId = 1;
        private const int KeyParameterLevelId = 1;
        private int CurrentRegionId = 1;

        private const int StartMidTermSubVarId = 17;

        private List<SubVariable> MidTermGenerationSubVariables;

        private List<SubVariableDailyData> _subVariableDailyData;

        private IEnumerable<SubVariableDailyData> SubVariableDailyData
        {
            get
            {
                if (_subVariableDailyData == null)
                {
                    initSubVariableDailyData();
                }
                return _subVariableDailyData;
            }
        }

        public SubVariableDailyDataRepository()
        {
            initMidTermGenerationSubVariables();
        }


        private void initMidTermGenerationSubVariables()
        {
            MidTermGenerationSubVariables = new List<SubVariable>();
            var currentSubNarId = StartMidTermSubVarId;

            foreach (var subVar in ElectricityTypes.SubVariables.GetAll())
            {
                var currentSubVar = new SubVariable
                {
                    Id = currentSubNarId++,
                    Name = subVar
                };
                MidTermGenerationSubVariables.Add(currentSubVar);
            }

        }


        #region Public methods of ISubVariableDailyDataRepository interface


        private IEnumerable<SubVariableDailyData> getSubVariableData(SubVariableDataQuery queryObj = null, bool includeRelated = false)
        {
            var query = SubVariableDailyData;
            return query;
        }


        public IEnumerable<SubVariableDailyData> GetSubVariableData(SubVariableDataQuery queryObj = null, bool includeRelated = false)
        {
            var query = SubVariableDailyData;
            return query;
        }

        #endregion Public methods of ISubVariableDailyDataRepository interface


        #region private Methods

        private void initSubVariableDailyData()
        {
            _subVariableDailyData = new List<SubVariableDailyData>();

            var rnd = new Random(700);

            for (var currRegion = 1; currRegion <= 1; currRegion++)
            {
                for (var currYear = 2010; currYear <= 2017; currYear++)
                {
                    for (var currMonth = 1; currMonth <= 12; currMonth++)
                    {
                        for (var currDayType = StartMidTermSubVarId; currDayType <= StartMidTermSubVarId + ElectricityTypes.SubVariables.Count - 1; currDayType++)
                        {
                            var subVariableDailyData = new SubVariableDailyData
                            {
                                ParentRegionId = ParentRegionId,
                                RegionAgrigationTypeId = RegionAgrigationTypeId,
                                RegionId = currRegion,
                                ScenarioId = ScenarioId,
                                VariableId = VariableId,
                                KeyParameterId = KeyParameterId,
                                KeyParameterLevelId = KeyParameterLevelId,
                                SubVariableId = currDayType,
                                SubVariable = MidTermGenerationSubVariables[currDayType - StartMidTermSubVarId],
                                Year = currYear,
                                Month = currMonth,
                                Value = rnd.Next(100, 700)
                            };
                            _subVariableDailyData.Add(subVariableDailyData);
                        }
                    }
                }
            }
        }

        public IEnumerable<SubVariableDailyData> GetSubVariableData()
        {
            var query = SubVariableDailyData;
            return query;
        }

        #endregion
    }
}