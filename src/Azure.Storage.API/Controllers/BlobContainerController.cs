using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get(string name)
        {
            //return ReturnActionResult(await _blobContainerRepository.GetBlobContainerByName(name, false));
            throw new NotImplementedException();
        }


        //[HttpPost]
        //public async Task Post([FromBody] BlobContainer blobContainer)
        //{
        //    await _blobContainerRepository.CreateNewBlobContainer(blobContainer);
        //}


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
