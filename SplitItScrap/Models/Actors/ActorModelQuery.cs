using System.ComponentModel;

namespace SplitItScrap.Models.Actors
{
    public class ActorModelQuery
    {
        public string ActorName { get; set; }
        public int? MinRank { get; set; }
        public int? MaxRank { get; set; }
        public string Provider { get; set; }

        [DefaultValue(0)]
        public int Skip { get; set; }
        
        [DefaultValue(20)]
        public int Take { get; set; }
    }
}
