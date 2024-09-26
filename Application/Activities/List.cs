using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        // This class represents a query to get a list of activities.
        // It implements IRequest from MediatR with a return type of List<Activity>.
        public class Query : IRequest<List<Activity>> { }

        // This class handles the Query request.
        // It implements IRequestHandler from MediatR with Query as the request type and List<Activity> as the response type.
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            // Private field to hold the instance of DataContext.
            private readonly DataContext _context;

            // Constructor to initialize the DataContext instance via dependency injection.
            public Handler(DataContext context)
            {
                _context = context;
            }

            // Method to handle the Query request.
            // It retrieves the list of activities from the database asynchronously.
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Fetches the list of activities from the database and returns it.
                return await _context.Activities.ToListAsync();
            }
        }
    }
}