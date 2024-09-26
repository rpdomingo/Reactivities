using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        // This class represents a query to get the details of a specific activity.
        // It implements IRequest from MediatR with a return type of Activity.
        public class Query : IRequest<Activity>
        {
            // The Id of the activity to retrieve.
            public Guid Id { get; set; }
        }

        // This class handles the Query request.
        // It implements IRequestHandler from MediatR with Query as the request type and Activity as the response type.
        public class Handler : IRequestHandler<Query, Activity>
        {
            // Private field to hold the instance of DataContext.
            private readonly DataContext _context;

            // Constructor to initialize the DataContext instance via dependency injection.
            public Handler(DataContext context)
            {
                _context = context;
            }

            // Method to handle the Query request.
            // It retrieves the activity with the specified Id from the database asynchronously.
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                // Fetches the activity with the specified Id from the database and returns it.
                return await _context.Activities.FindAsync(request.Id);
            }
        }
    }
}