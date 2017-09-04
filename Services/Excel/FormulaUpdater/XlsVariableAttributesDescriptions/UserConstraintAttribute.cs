using NXS.Services.Abstract.XlsFormulaUpdater;

namespace NXS.Services.Excel.FormulaUpdater.XlsVariableAttributesDescriptions
{
    public class UserConstraintAttribute : XlsAttributeVariableDescriptionAbstract
    {
        public UserConstraintAttribute() {
            ColLetter = "O";
        }
    }
}