using Campaign.Domain.Common;

namespace Campaign.Domain.Entities
{
    public class Campaign : EntityBase
    {
        public Campaign()
        {
        }

        public Campaign(Guid id)
        {
            Id = id;
        }

        public string Name { get; set; }

        public string Query { get; set; }

        public TimeSpan Time { get; set; }

        public int Priority { get; set; }

        public Guid TemplateId { get; set; }

        public Template Template { get; set; }
    }
}
