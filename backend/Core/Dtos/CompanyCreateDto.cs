using backend.Core.Enums;

namespace backend.Core.Dtos
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
