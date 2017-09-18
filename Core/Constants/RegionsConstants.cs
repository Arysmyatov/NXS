using System.Collections;
using System.Collections.Generic;

namespace NXS.Core.NxsConstants
{
    public static class RegionConstants
    {
        public static Dictionary<string, string> ToSkipWords
        {
            get
            {
                return new Dictionary<string, string> { { "TOTAL", "Total" } };
            }
        }


        public static bool IsNotAllowed(string regionName)
        {
            return ToSkipWords.ContainsKey(regionName.ToUpper());
        }


        public static class Types
        {
            public static string ByRegion { get; } = "By Region";
            public static string World { get; } = "World";
        }

        public static string WorldRegionName { get; } = "World";

        public static class ParentRegions
        {
            public static string Etm { get; } = "ETM";
            public static string Tmxr { get; } = "TMXR";
        }
        
    }
}