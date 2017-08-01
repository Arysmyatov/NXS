namespace NXS.Controllers.Resources
{
    public class VariableXlsResource
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SheetName { get; set; }
        public int YearBgRow { get; set; }
        public int YearBgCol { get; set; }
        public int YearEndRow { get; set; }
        public int YearEndCol { get; set; }
        public int DataBgRow { get; set; }
        public int DataBgCol { get; set; }
        public int DataEndRow { get; set; }
        public int DataEndCol { get; set; }
        public int VariableId { get; set; }
        public int XlsRegionTypeId { get; set; }
    }
}