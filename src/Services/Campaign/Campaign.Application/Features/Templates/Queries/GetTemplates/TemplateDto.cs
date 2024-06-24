using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Features.Templates.Queries.GetTemplates
{
    public class TemplateDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public byte[] Contents { get; set; }
    }
}
