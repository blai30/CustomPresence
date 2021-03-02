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

        public override string ToString()
        {
            return
                $"{GetType().Name}\n" +
                $"\tClientId: {ClientId.ToString()}\n" +
                $"\tDetails: {Details}\n" +
                $"\tState: {State}\n" +
                $"\tStartTimestamp: {StartTimestamp.ToString()}\n" +
                $"\tEndTimestamp: {EndTimestamp.ToString()}\n" +
                $"\tLargeImageKey: {LargeImageKey}\n" +
                $"\tLargeImageText: {LargeImageText}\n" +
                $"\tSmallImageKey: {SmallImageKey}\n" +
                $"\tSmallImageText: {SmallImageText}\n" +
                $"\tPartyId: {PartyId}\n" +
                $"\tPartySize: {PartySize.ToString()}\n" +
                $"\tPartyMax: {PartyMax.ToString()}\n" +
                $"\tMatchSecret: {MatchSecret}\n" +
                $"\tSpectateSecret: {SpectateSecret}\n" +
                $"\tJoinSecret: {JoinSecret}\n" +
                $"\tInstance: {Instance.ToString()}\n"
                ;
        }
    }
}
