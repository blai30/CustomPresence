namespace CustomPresence.Options
{
    public class DiscordOptions
    {
        public long ClientId { get; set; }
        public string? Details { get; set; }
        public string? State { get; set; }
        public long? StartTimestamp { get; set; }
        public long? EndTimestamp { get; set; }
        public string? LargeImageKey { get; set; }
        public string? LargeImageText { get; set; }
        public string? SmallImageKey { get; set; }
        public string? SmallImageText { get; set; }
        public string? PartyId { get; set; }
        public int? PartySize { get; set; }
        public int? PartyMax { get; set; }
        public string? MatchSecret { get; set; }
        public string? SpectateSecret { get; set; }
        public string? JoinSecret { get; set; }
        public bool? Instance { get; set; }
    }
}
