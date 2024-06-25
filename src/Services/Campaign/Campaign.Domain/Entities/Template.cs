using Campaign.Domain.Common;

namespace Campaign.Domain.Entities;

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
