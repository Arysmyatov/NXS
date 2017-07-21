namespace NXS.Controllers.Resources
{
    public class XlsUploadResource
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int ScenarioId  { get; set; }
        public int KeyParameterId  { get; set; }
        public int KeyParameterLevelId  { get; set; }        
        
    }
}