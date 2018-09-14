using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.BlobAccess.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Azure.BlobAccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobContainerController : BaseController
  {
        private readonly IBlobContainerRepository _blobContainerRepository;          

        public BlobContainerController(IBlobContainerRepository blobContainerRepository)
        {
            _blobContainerRepository = blobContainerRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return ReturnActionResult(await _blobContainerRepository.GetAllBlobContainers());
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return ReturnActionResult(await _blobContainerRepository.GetBlobContainerByName(name));
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
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
