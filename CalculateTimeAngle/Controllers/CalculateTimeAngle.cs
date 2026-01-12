using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculateTimeAngle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateTimeAngle : ControllerBase
    {
        private static readonly Dictionary<int, int> HourDegrees = new Dictionary<int, int>
        {
            [12] = 0,
            [1] = 30,
            [2] = 60,
            [3] = 90,
            [4] = 120,
            [5] = 150,
            [6] = 180,
            [7] = 210,
            [8] = 240,
            [9] = 270,
            [10] = 300,
            [11] = 330
        };

        public CalculateTimeAngle()
        {
        }

        [HttpGet("{hour},{minute}")]
        public string Get(string hour, string minute)
        {
            int result = 0;
            int minutes;

            try
            {
                if(hour.Length > 2 || minute.Length > 2 ) 
                {
                    new Exception();
                }
                
                int.TryParse(minute, out minutes);
                if (minutes < 0 || minutes > 59)
                {
                    throw new Exception();
                }
                result = HourDegrees[int.Parse(hour)];
                result += minutes;
                return ($"{result} degrees");
            }
            catch (Exception)
            {

                return "Error Calculating the Degrees";
            }
        }

        [HttpGet("{time}")]
        public string Get(string time)
        {
            int result = 0;
            int minutes = 0;
            try
            {
               string[] segments = time.Split(":");
               if(segments.Length != 2 ) 
                {
                    throw new Exception();
                }

                if (segments[0].Length > 2 || segments[1].Length > 2)
                {
                    throw new Exception();
                }

                int.TryParse(segments[1], out minutes);
                if (minutes < 0 || minutes > 59)
                {
                    throw new Exception();
                }
                result = HourDegrees[int.Parse(segments[0])];
                result += minutes;
                return ($"{result} degrees");
                
                 
            }
            catch (Exception)
            {

                return "Error Calculating the Degrees";
            }
           
        }
    }
}
