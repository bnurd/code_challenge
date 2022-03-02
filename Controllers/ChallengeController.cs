using code_challenge.Dto;
using code_challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace code_challenge.Controllers
{
    // + https://domain/challenge/ POST
    // + https://domain/challenge/
    // + https://domain/challenge/rand
    // + https://domain/challenge/1
    // + https://domain/challenge/1 -> text 
    // - https://domain/challenge/beginner
    // - https://domain/challenge/middle
    // - https://domain/challenge/expert

    // - https://domain/challenge/1/solve

    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {
        public static List<Challenge> challenges = new List<Challenge>();

        [HttpPost("multiline")]
        public async Task<ActionResult> Multiline([FromForm] PostChallengeDto challengeDto)
        {
            var challenge = new Challenge
            {
                Id = 1,
                Content = challengeDto.Content,
                Degree = challengeDto.Degree,
                Output = challengeDto.Output
            };

            challenges.Add(challenge);
            
            return Content(challenge.ToString(), "text/html");
        }

        [HttpPost]
        public async Task<ActionResult<Challenge>> Post(PostChallengeDto challengeDto)
        {
            var challenge = new Challenge
            {
                Id = 1,
                Content = challengeDto.Content,
                Degree = challengeDto.Degree,
                Output = challengeDto.Output
            };

            challenges.Add(challenge);

            return challenge;
        }

        [HttpGet]
        public async Task<ActionResult<List<Challenge>>> Get()
        {
            return challenges;
        }

        [HttpGet("rand")]
        public ActionResult<Challenge> GetRand()
        {
            var rand = new Random();
            var index = rand.Next(0, challenges.Count());
            return challenges[index];
        }

        [HttpGet("id/{id}")]
        public ActionResult<List<String>> GetById(int id)
        {
            return challenges[id].Output.Split("\n").ToList();
        }

        [HttpGet("{degree}")]
        public ActionResult<List<Challenge>> GetByDegree(int degree)
        {
            return challenges.Where(x => (int)x.Degree == degree).ToList();
        }

        [HttpGet("{hard}")]
        public ActionResult<List<Challenge>> GetByHard(Degree hard)
        {

            return challenges.Where(x => x.Degree == hard).ToList();
        }

        [HttpGet("degree/{deg}")]
        public ActionResult<List<Challenge>> GetByDeg(String deg)
        {
            var degree = deg.Substring(0, 1).ToUpper() + deg.Substring(1).ToLower();
            if (!Enum.IsDefined(typeof(Degree), degree))
                return NotFound();

            return challenges.Where(x => x.Degree.ToString().ToLower() == deg.ToLower()).ToList();
        }

    }
}