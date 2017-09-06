using System.Collections.Generic;
using NXS.Services.Abstract.XlsStucture;

namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public abstract class XlsVariableDescriptionAbstract : IXlsVariableDescription
    {
        public IXlsRange[] XlsRanges { get; set; }
        public IXlsSrcDescription XlsSrcDescription { get; set; }
        public string NegativeChangeLetter { get; set; }
        public ICollection<IXlsAttributeVariableDescription> XlsAttributeVariableDescriptions { get; set; }

        public XlsVariableDescriptionAbstract()
        {
            NegativeChangeLetter = string.Empty;
        }
    }
}