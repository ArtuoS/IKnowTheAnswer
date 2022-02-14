using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;

namespace IKnowTheAnswer.PresentationLayer.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Question, QuestionDto>();
                cfg.CreateMap<QuestionDto, Question>();

                cfg.CreateMap<QuestionLoggerDto, QuestionLogger>();
                cfg.CreateMap<QuestionLogger, QuestionLoggerDto>();

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
            });
        }
    }
}
