using AutoMapper;
using IKnowTheAnswer.Presentation.DTOs;
using IKnowTheAnswer.Presentation.Entities;

namespace IKnowTheAnswer.Presentation.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserGetDto>().ReverseMap();
        }
    }
}
