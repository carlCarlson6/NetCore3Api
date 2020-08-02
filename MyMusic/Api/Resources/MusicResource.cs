using System;

namespace Api.Resources
{
    public class MusicResource
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ArtistResource Artist { get; set; }
    }
}
