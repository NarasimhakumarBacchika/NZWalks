﻿namespace NZWalks.API.Model.Data
{
    public class Walk
    {

        public Guid Id { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }


        public Guid DiffcultyId { get; set; }

        public Guid RegionId { get; set; }

        public Diffculty Diffculty { get; set; }

        public Region Region { get; set; }  



    }
}
