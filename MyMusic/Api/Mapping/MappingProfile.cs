using Api.Resources;
using AutoMapper;
using Core.Models;

namespace Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // domain to resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();

            // resource to domain
            CreateMap<MusicResource, Music>();
            CreateMap<ArtistResource, Artist>();
        }
    }
}
