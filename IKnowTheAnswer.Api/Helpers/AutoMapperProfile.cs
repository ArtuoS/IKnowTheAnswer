using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.DTOs.Question;
using IKnowTheAnswer.Core.DTOs.User;
using IKnowTheAnswer.Core.Entities;

namespace IKnowTheAnswer.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<QuestionLogger, QuestionLoggerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserInsertDto, UserDto>().ReverseMap();

            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<UserGetDto, User>().ReverseMap();
            CreateMap<UserInsertDto, User>().ReverseMap();

            CreateMap<QuestionGetDto, User>().ReverseMap();
            CreateMap<QuestionInsertDto, User>().ReverseMap();
            CreateMap<QuestionUpdateDto, User>().ReverseMap();
        }
    }
}