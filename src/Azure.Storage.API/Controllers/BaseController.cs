using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.BlobAccess.API.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());


        public IActionResult ReturnActionResult<T>(T data)
        {
            if (data == null)
            {
                return NotFound();
            }
            return Json(data);
        }
    }
}
