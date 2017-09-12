
using Microsoft.AspNetCore.Http;

namespace NXS.Controllers.Resources
{
    public class XlsFileResource
    {
        public int ParentRegion { get; set; }
        public int Scenario { get; set; }
        public int KeyParameter { get; set; }
        public int KeyParameterLevel { get; set; }
        public int Region { get; set; }
        public IFormFile File { get; set; }
    }
}