using System;
using System.Diagnostics;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.TotalAnesthesia.Commands;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Domain.Activity Activity { get; set; }
    }
    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.TotalAnesthesiaCare.FindAsync([request.Activity.Id], cancellationToken)
                ?? throw new Exception("Cannot find Activity");

            mapper.Map(request.Activity, activity);

            await context.SaveChangesAsync(cancellationToken);


        }
    }
}
