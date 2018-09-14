using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.BlobAccess.API.Controllers
{
    public class BaseController : Controller
    {
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
