using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class QuizValidator : AbstractValidator<Quiz>
    {
        public QuizValidator()
        {
            RuleFor(u => u.Questions).NotEmpty();
            RuleFor(u => u.QuizName).NotEmpty();

        }
    }
}
