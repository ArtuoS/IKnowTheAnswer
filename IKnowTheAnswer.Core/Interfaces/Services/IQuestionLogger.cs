using IKnowTheAnswer.Core.DTOs;
using IKnowTheAnswer.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTheAnswer.Core.Interfaces.Services
{
    public interface IQuestionLogger
    {
        void Log(QuestionLoggerDto questionLoggerDto);
    }
}