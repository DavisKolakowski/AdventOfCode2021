// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day1.Controllers
{
    using Day1.ResponseObjects;

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
            var result = new List<int>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.Add(Convert.ToInt32(await reader.ReadLineAsync()));
            }
            var items = result.ToList();

            var list = new List<int>();

            for (int i = 1; i < result.Count - 2; i++)
            {
                var A = items[i - 1] + items[i] + items[i + 1];
                var B = items[i] + items[i + 1] + items[i + 2];
                if (A < B)
                {
                    list.Add(B);
                }
            }

            return list.Count;
        }
    }
}

