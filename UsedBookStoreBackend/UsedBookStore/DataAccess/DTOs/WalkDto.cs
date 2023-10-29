﻿using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.DTOs
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        public Difficulty Difficulty { get; set; }
    }
}
