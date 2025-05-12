using System;

namespace SplitItScrap.Domain.Services.Actors.Entities
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string Details { get; set; }
        public ProviderTypeCode Provider { get; set; }
    }
}
