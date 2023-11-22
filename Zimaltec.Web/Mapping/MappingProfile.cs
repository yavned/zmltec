using AutoMapper;
using Zimaltec.Business.Models;
using Zimaltec.Entities.Models;

namespace Zimaltec.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ZimaltecTask, InsertZimaltecTaskDTO>().ReverseMap();
            CreateMap<ZimaltecTask, UpdateZimaltecTaskDTO>().ReverseMap();
        }
    }
}