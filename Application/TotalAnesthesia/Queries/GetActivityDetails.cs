using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Domain;
using MediatR;
using Persistence;

namespace Application.TotalAnesthesia.Queries;

public class GetActivityDetails
{
    public class Query : IRequest<Activity>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity = await context.TotalAnesthesiaCare.FindAsync([request.Id], cancellationToken);

            if (activity == null) throw new Exception("Not Found");
            return activity;
        }
    }

}
