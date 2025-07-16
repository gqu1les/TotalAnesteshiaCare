using System;
using MediatR;
using Persistence;

namespace Application.TotalAnesthesia.Commands;

public class DeleteActivity
{
    public class Commands : IRequest
    {
        public required string Id { get; set; }
    }
    public class Handler(AppDbContext context) : IRequestHandler<Commands>
    {
        public async Task Handle(Commands request, CancellationToken cancellationToken)
        {
            var activity = await context.TotalAnesthesiaCare.FindAsync([request.Id], cancellationToken)
                ?? throw new Exception("Cannot find Activity");

            context.Remove(activity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
