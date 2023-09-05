using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Helpers.Mapper
{

    public class MapperProfile : Profile
    {

        MapperProfile()
        {
            CreateMap<Utilizator, UtilizatorDTO>();
        }
    }

}