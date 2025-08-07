using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.TotalAnesthesia.Queries;

public class GetActivityDetails
{
    public class Query : IRequest<Results<Activity>>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Results<Activity>>
    {
        public async Task<Results<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity = await context.TotalAnesthesiaCare.FindAsync([request.Id], cancellationToken);

            if (activity == null) return Results<Activity>.Failure("Activity not found", 404);

            return Results<Activity>.Success(activity);
        }
    }

}
