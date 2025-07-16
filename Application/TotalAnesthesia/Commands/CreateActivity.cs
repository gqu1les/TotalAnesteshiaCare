using System;
using Domain;
using MediatR;
using Persistence;

namespace Application.TotalAnesthesia.Commands;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        { 
            context.TotalAnesthesiaCare.Add(request.Activity);
            await context.SaveChangesAsync();
            return request.Activity.Id;
        }
    }
}
