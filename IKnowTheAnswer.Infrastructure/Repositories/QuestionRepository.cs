using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using IKnowTheAnswer.Infrastructure.Repositories.DatabaseContext;

namespace IKnowTheAnswer.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IKnowTheAnswerDbContext _db;
        private readonly IMapper _mapper;

        public QuestionRepository(IKnowTheAnswerDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseDto<QuestionDto>> Delete(int id)
        {
            var responseDto = new ResponseDto<QuestionDto>();

            try
            {
                using (var db = _db)
                {
                    var question = db.Questions.FirstOrDefault(x => x.Id == id);

                    if (question != null)
                    {
                        db.Questions.Remove(question);
                        await db.SaveChangesAsync();

                        responseDto.Success = true;
                        responseDto.Message = "Deleted!";
                    }
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto<QuestionDto>> Get(int id)
        {
            var responseDto = new ResponseDto<QuestionDto>();

            try
            {
                using (var db = _db)
                {
                    var question = db.Questions.FirstOrDefault(x => x.Id == id);

                    if (question != null)
                    {
                        responseDto.Data = _mapper.Map<QuestionDto>(question);
                        responseDto.Success = true;
                        responseDto.Message = "Deleted!";
                    }
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto<IList<QuestionDto>>> GetAll(int id)
        {
            var responseDto = new ResponseDto<IList<QuestionDto>>();

            try
            {
                using (var db = _db)
                {
                    var questions = db.Questions.Where(x => x.Id == id)
                                      .ToList();

                    if (questions.Any())
                    {
                        responseDto.Data = _mapper.Map<IList<QuestionDto>>(questions);
                        responseDto.Success = true;
                        responseDto.Message = "Deleted!";
                    }
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto<QuestionDto>> Insert(QuestionDto questionDto)
        {
            var responseDto = new ResponseDto<QuestionDto>();

            try
            {
                using (var db = _db)
                {
                    var question = _mapper.Map<Question>(questionDto);

                    await db.Questions.AddAsync(question);
                    await db.SaveChangesAsync();

                    responseDto.Data = _mapper.Map<QuestionDto>(question);
                    responseDto.Success = true;
                    responseDto.Message = "Created!";
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }

        public async Task<ResponseDto<QuestionDto>> Update(QuestionDto questionDto)
        {
            var responseDto = new ResponseDto<QuestionDto>();

            try
            {
                using (var db = _db)
                {
                    var question = _mapper.Map<Question>(questionDto);

                    db.Questions.Update(question);
                    await db.SaveChangesAsync();

                    responseDto.Data = _mapper.Map<QuestionDto>(question);
                    responseDto.Success = true;
                    responseDto.Message = "Updated!";
                }
            }
            catch (Exception ex)
            {
                responseDto.Success = false;
                responseDto.Message = ex.Message;
            }

            return responseDto;
        }
    }
}
