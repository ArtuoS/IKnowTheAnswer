using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using IKnowTheAnswer.Infrastructure.Repositories.DatabaseContext;

namespace IKnowTheAnswer.Infrastructure.Repositories
{
    public class QuestionLoggerRepostory : IQuestionLoggerRepository
    {
        private readonly IKnowTheAnswerDbContext _dbContext;
        private readonly IMapper _mapper;

        public QuestionLoggerRepostory(IKnowTheAnswerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async void Log(QuestionLoggerDto questionLoggerDto)
        {
            using (var db = _dbContext)
            {
                var questionLogger = _mapper.Map<QuestionLogger>(questionLoggerDto);

                await db.QuestionLoggers.AddAsync(questionLogger);
                await db.SaveChangesAsync();
            }
        }
    }
}
