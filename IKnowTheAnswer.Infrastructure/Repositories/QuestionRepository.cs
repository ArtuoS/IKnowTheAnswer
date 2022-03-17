using AutoMapper;
using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.DTOs.Question;
using IKnowTheAnswer.Core.Entities;
using IKnowTheAnswer.Core.Interfaces.Repositories;
using IKnowTheAnswer.Infrastructure.Repositories.DatabaseContext;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ResponseDto> Insert(QuestionInsertDto questionDto)
        {
            var responseDto = new ResponseDto();

            try
            {
                using (var db = _db)
                {
                    var question = _mapper.Map<Question>(questionDto);

                    await db.Questions.AddAsync(question);
                    await db.SaveChangesAsync();

                    responseDto.Data = question;
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

        public async Task<ResponseDto> Update(int id, QuestionUpdateDto questionDto)
        {
            var responseDto = new ResponseDto();

            try
            {
                using (var db = _db)
                {
                    var question = _mapper.Map<Question>(questionDto);

                    db.Questions.Update(question);
                    await db.SaveChangesAsync();

                    responseDto.Data = question;
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

        public async Task<ResponseDto> Delete(int id)
        {
            var responseDto = new ResponseDto();

            try
            {
                using (var db = _db)
                {
                    var question = await db.Questions.FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task<ResponseDto> Get(int id)
        {
            var responseDto = new ResponseDto();

            try
            {
                using (var db = _db)
                {
                    var question = await db.Questions.FirstOrDefaultAsync(x => x.Id == id);

                    if (question != null)
                    {
                        responseDto.Data = question;
                        responseDto.Success = true;
                        responseDto.Message = $"Select Question {question.Title}!";
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

        public async Task<ResponseDto> GetAll()
        {
            var responseDto = new ResponseDto();

            try
            {
                using (var db = _db)
                {
                    var questions = await db.Questions.ToListAsync();

                    if (questions.Any())
                    {
                        responseDto.Data = questions;
                        responseDto.Success = true;
                        responseDto.Message = "Selected All Questions!";
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
    }
}