namespace Day2.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Text;

    [Route("api/[controller]")]
    [ApiController]
    public class PartOneController : ControllerBase
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
            var lines = result.ToString().Split(Environment.NewLine);

            var horizontalPosition = new List<int>();
            var depth = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                var lineSplit = lines[i].Split(' ', StringSplitOptions.TrimEntries);
                if (lineSplit[0] == "forward")
                {
                    horizontalPosition.Add(Convert.ToInt32(lineSplit[1]));
                }
                if (lineSplit[0] == "down")
                {
                    depth.Add(Convert.ToInt32(lineSplit[1]));
                }
                if (lineSplit[0] == "up")
                {
                    depth.Add(-Convert.ToInt32(lineSplit[1]));
                }
            }

            var total = horizontalPosition.Sum() * depth.Sum();

            return total;
        }
    }
}
