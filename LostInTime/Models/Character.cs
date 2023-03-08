namespace LostInTime.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string? Name { get; set; }
        public CharacterClass Class { get; set; }
        public ulong Level { get; set; }
        public ulong ItemLevel { get; set; }
    }
}
