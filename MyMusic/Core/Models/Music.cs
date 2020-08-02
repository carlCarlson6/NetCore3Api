using System;

namespace Core.Models
{
    public class Music
    {
        public int Id {get; set;}
        public String Name {get; set;}
        public int ArtitstId {get; set;}
        public Artist Artist {get; set;} 
    }
}