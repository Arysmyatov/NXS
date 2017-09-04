namespace NXS.Services.Abstract.XlsFormulaUpdater
{
    public interface IXlsAttributeVariableDescriptions
    {
        IXlsAttributeVariableDescription ProcessSetAtribute { get; set; }
        IXlsAttributeVariableDescription CommodityAttribute { get; set; }
        IXlsAttributeVariableDescription CommoditySetAttribute { get; set; }        
        IXlsAttributeVariableDescription AttributeAttribute { get; set; }
        IXlsAttributeVariableDescription UserConstraintAttribute { get; set; }
    }
}