// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day1.Controllers
{
    using Microsoft.AspNetCore.Components.Forms;
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;
    using System.Reflection.PortableExecutable;
    using System.Text;

    [Route("api/[controller]")]
    [ApiController]
    public class PartTwoController : ControllerBase
    {
        [HttpPost]
        public async Task<int> Post(IFormFile file)
        {
            var input = new List<int>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    input.Add(Convert.ToInt32(await reader.ReadLineAsync()));
            }

            var result = input.Skip(3)
                .Select((x, i) => x > input[i])
                .Count(x => x);

            return result;
        }
    }
}

