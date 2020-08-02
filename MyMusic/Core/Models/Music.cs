using System;

namespace Core.Models
{
    public class Music
    {
        public int Id {get; set;}
        public String Name {get; set;}
        public int ArtistId {get; set;}
        public Artist Artist {get; set;} 
    }
}