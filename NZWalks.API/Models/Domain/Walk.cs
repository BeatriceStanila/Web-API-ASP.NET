namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl {  get; set; } //nullable

        // Connections between these domain models
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        // Navigation properties
        public Difficulty Difficulty { get; set; } // this tells Entity Framework Core that a Walk will have a Difficulty 
        public Region Region { get; set; } // defines a one-to-one relationship between a Walk and a Region 

    }
}
