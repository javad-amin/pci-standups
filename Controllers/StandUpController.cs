using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PCI.Controllers
{
    [ApiController]
    [Route("[controller]/{id?}")]
    public class StandUpController : Controller
    {
        private readonly FreeStandUps main;
        private readonly IMapper mapper;

        public StandUpController(FreeStandUps main, IMapper mapper)
        {
            this.mapper = mapper;
            this.main = main;
        }

        [HttpPost("")]
        public IEnumerable<StandUpResource> PostStandUps(int id, [FromBody] Schedule schedule)
        {

            var standUps = main.GetFreeStandUps(schedule, id);

            return mapper.Map<List<StandUp>, List<StandUpResource>>(standUps); 
        }
    }
}