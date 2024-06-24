using Campaign.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Domain.Entities
{
    public class Template: EntityBase
    {
        public Template() { }

        public Template(Guid id)
        {
            Id = id;
        }
        public string Name { get; set; }
        public byte[] Contents { get; set; }
    }
}
