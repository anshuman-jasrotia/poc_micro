using AutoMapper;
using CommandService.Data;
using CommandService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{

    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformreadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from CommandsService");
            var platformItems = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformreadDto>>(platformItems));
        }

        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST #Command Service");
            return Ok("Inbound test of Command service");
        }
    }
}