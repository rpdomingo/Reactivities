using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // This attribute indicates that this class is an API controller
    [ApiController]
    // This attribute defines the route for the controller, using the controller's name as the base route
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        // Private field to hold the instance of IMediator
        private IMediator _mediator;

        // Protected property to get the IMediator instance, initializing it if it hasn't been already
        protected IMediator Mediator => _mediator ??= 
            HttpContext.RequestServices.GetService<IMediator>();
    }
}