using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.TotalAnesthesia.Queries;

public class GetActivityList
{
    public class Query : IRequest<List<Activity>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
    {
        public  async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.TotalAnesthesiaCare.ToListAsync(cancellationToken);
        }
    }
}
