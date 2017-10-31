using System.Collections.Generic;

namespace NXS.Core.Constants
{
    public class ElectricityTypes
    {
        public static class SubVariables
        {
            public static string WDMID { get; } = "WD-MID";
            public static string WDOFF { get; } = "WD-OFF";
            public static string WDON { get; } = "WD-ON";
            public static string WEMID { get; } = "WE-MID";
            public static string WEOFF { get; } = "WE-OFF";
            public static string WEON { get; } = "WE-ON";

            public const int Count = 6;

            public static IEnumerable<string> GetAll()
            {
                return new string[] {
                    WDMID,
                    WDOFF,
                    WDON,
                    WEMID,
                    WEOFF,
                    WEON
                };
            }
        }
    }
}