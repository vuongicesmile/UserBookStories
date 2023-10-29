namespace UsedBookStore.DataAccess.DTOs
{
    public class AddRequestWalksDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }

        //public Guid RegionId { get; set; }
    }
}
