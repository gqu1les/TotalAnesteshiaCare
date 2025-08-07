using System;
using Application.TotalAnesthesia.Commands;
using Application.TotalAnesthesia.DTO;
using FluentValidation;

namespace Application.TotalAnesthesia.Validators;

public class EditActivityValidator : BaseActivityValidator<EditActivity.Command, EditActivityDTO>
{
    public EditActivityValidator() : base(X => X.ActivityDTO)
    {
        RuleFor(X => X.ActivityDTO.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}
