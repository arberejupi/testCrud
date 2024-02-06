using AppointEase.Domain.AppointEase.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointEase.Application.AppointEase.Application.Validator
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(person => person.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(person => person.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(person => person.Age).GreaterThan(0).WithMessage("Age must be greater than 0.");
        }
    }
}
