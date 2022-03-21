﻿using IKnowTheAnswer.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace IKnowTheAnswer.Core.DTOs.Question
{
    public class QuestionUpdateDto
    {
        public string Title { get; set; }
        public string Answer { get; set; }
        public IList<Picture> Pictures { get; set; }
        public int UserId { get; set; }
    }
}