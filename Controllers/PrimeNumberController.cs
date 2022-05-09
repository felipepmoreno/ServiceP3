using Microsoft.AspNetCore.Mvc;
using ServiceP3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceP3.Controllers
{
    [Route("api/p3/generate-token")]
    [ApiController]
    public class PrimeNumberController : ControllerBase
    {
        public IFindPrimes _findPrimesService;
        public HttpClient client = new HttpClient();
        public PrimeNumberController(IFindPrimes findPrimesService)
        {
            _findPrimesService = findPrimesService;
        }

        [HttpPost]
        public async Task<string> Token([FromBody] P3BodyModel model)
        {
            try
            {
                string primeHash = _findPrimesService.GenerateHash(model.n, model.code);
                return "Hash Gerada: " + primeHash;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
        }

    }
}
