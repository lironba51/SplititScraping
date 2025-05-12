using SplitItScrap.Domain.Services.Actors.Entities;
using System;

namespace SplitItScrap.Models.Actors
{
    public class ActorModelView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string Details { get; set; }
        public string Provider { get; set; }
    }
}
