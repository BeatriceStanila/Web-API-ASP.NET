﻿namespace NZWalks.API.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; } //nullable

        // Connections between these domain models
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }
    }
}