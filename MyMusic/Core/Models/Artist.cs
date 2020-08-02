using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Models
{
    public class Artist
    {
        public Artist() => this.Musics = new Collection<Music>();
    
        public int Id {get; set;}
        public string Name {get; set;}
        public ICollection<Music> Musics {get; set;}
    }
}