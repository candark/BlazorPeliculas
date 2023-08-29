using AutoMapper;
using BlazorPeliculas.Shared.DTO;
using BlazorPeliculas.Shared.Entidades;

namespace BlazorPeliculas.Server.Helpers
{
    public class AutomapperProfiles: Profile
    {

        public AutomapperProfiles() { 
            CreateMap<Actor, Actor>()
                .ForMember(x => x.Foto, option => option.Ignore());

            CreateMap<Pelicula, Pelicula>()
                .ForMember(x => x.Poster, option => option.Ignore());

            CreateMap<VotoPeliculaDTO, VotoPelicula>();
        }

    }
}
