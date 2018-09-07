using Asp.AngularCore.git.Data.Entities;
using Asp.AngularCore.git.ViewModel;
using AutoMapper;

namespace Asp.AngularCore.git.Data
{
    public class LKMappingProfile : Profile
    {
        public LKMappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
