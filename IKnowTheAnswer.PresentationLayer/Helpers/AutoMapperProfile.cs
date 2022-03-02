using AutoMapper;
using IKnowTheAnswer.Application.Models.Views;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;

namespace IKnowTheAnswer.PresentationLayer.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionLogger, QuestionLoggerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserPostViewModel, UserDto>().ReverseMap();
        }
    }
}
