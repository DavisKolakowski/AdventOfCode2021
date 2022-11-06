namespace Day2.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Text;

    [Route("api/[controller]")]
    [ApiController]
    public class PartTwoController : ControllerBase
    {
        [HttpPost]
        public async Task<int> Post(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }           
            var lines = result.ToString().Split(Environment.NewLine).ToList();

            var x = 0;
            var y = 0;
            var aim = 0;

            foreach (var line in lines)
            {
                var lineSplit = line.Split(' ', StringSplitOptions.TrimEntries);
                switch(lineSplit[0])
                {
                    case "forward" : 
                            x += Convert.ToInt32(lineSplit[1]);
                            y += Convert.ToInt32(lineSplit[1]) * aim;
                        break;
                    case "down" : 
                            aim += Convert.ToInt32(lineSplit[1]);
                        break;
                    case "up" : 
                            aim -= Convert.ToInt32(lineSplit[1]);
                        break;
                }
            }

            var total = x * y;

            return total;
        }
    }
}
