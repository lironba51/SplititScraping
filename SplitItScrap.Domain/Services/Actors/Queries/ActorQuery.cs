namespace SplitItScrap.Domain.Services.Actors.Queries
{
    public class ActorQuery
    {
        public string ActorName { get; set; }
        public int? MinRank { get; set; }
        public int? MaxRank { get; set; }
        public string Provider { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
