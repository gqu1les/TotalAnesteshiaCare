using System;
using Application.TotalAnesthesia.Commands;
using Application.TotalAnesthesia.DTO;
using FluentValidation;

namespace Application.TotalAnesthesia.Validators;

public class CreateActivityValidator : BaseActivityValidator<CreateActivity.Command, CreateActivityDto>
{
    public CreateActivityValidator() : base(x => x.ActivityDto)
    {
        
    }

}
