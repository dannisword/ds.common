using AutoMapper;
using DS.Common.Dto;
using DS.Webapi.Controllers.Parameters;
using DS.Webapi.Controllers.ViewModels;

namespace DS.Webapi.Infrastructure
{
    public class ControllerProfile : Profile
    {
        public ControllerProfile()
        {
            this.CreateMap<BlogQueryParameter, BlogQueryDto>();
            this.CreateMap<BlogDto, BlogViewModel>();

            this.CreateMap<BlogDto, BlogDto>();
        }
    }
}