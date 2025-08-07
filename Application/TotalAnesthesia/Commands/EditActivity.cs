using System;
using System.Diagnostics;
using Application.Core;
using Application.TotalAnesthesia.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.TotalAnesthesia.Commands;

public class EditActivity
{
    public class Command : IRequest<Results<Unit>>
    {
        public required EditActivityDTO ActivityDTO { get; set; }
    }
    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Results<Unit>>
    {
        public async Task<Results<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.TotalAnesthesiaCare.FindAsync([request.ActivityDTO.Id], cancellationToken);

            if (activity == null) return Results<Unit>.Failure("Activity not found", 404);

            mapper.Map(request.ActivityDTO, activity);

            var result = await context.SaveChangesAsync(cancellationToken) > 0;

            if (!result) return Results<Unit>.Failure("Failed to delete activity", 400);

            return Results<Unit>.Success(Unit.Value);

        }
    }
}
