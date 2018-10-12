using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Storage.Application.BlobContainers.Commands;
using Azure.Storage.Application.BlobContainers.Models;
using Azure.Storage.Application.BlobContainers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Azure.BlobAccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobContainerController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return ReturnActionResult(await Mediator.Send(new GetAllBlobContainersQuery()));
        }


        [HttpGet("{name}")]
        [ProducesResponseType(typeof(BlobContainerViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string name)
        {            
            return ReturnActionResult(await Mediator.Send(new GetBlobContainerQuery(name, false)));
        }


        [HttpPost]
        [ProducesResponseType(typeof(BlobContainerViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] CreateBlobContainerCommand command)
        {
            return ReturnActionResult(await Mediator.Send(command));
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
