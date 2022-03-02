﻿using System.ComponentModel;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace IKnowTheAnswer.Application.Models.Views
{
    public class UserPostViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Ignore]
        [DisplayName("Repeat Password")]
        public string ConfirmPassword { get; set; }
    }
}
