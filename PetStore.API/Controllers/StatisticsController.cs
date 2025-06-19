using Microsoft.AspNetCore.Mvc;
using PetStore.Data.Repositoriy.Interface;
using PetStore.Model.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetStore.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IPetRepository petRepository;

        public StatisticsController(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        // GET: api/Statistics
        [HttpGet]
        public async Task<ActionResult<StatisticsDTO>> GetStatistics()
        {
            var petsResult = await this.petRepository.FindAll();
            var pets = petsResult.Select(p => new PetDTO()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                BirthDate = p.BirthDate,
                AnimalType = (int)p.AnimalType,
                Sex = p.Sex,
                Price = p.Price,
            });
            var statisticsDTO = new StatisticsDTO(pets);
            return Ok(statisticsDTO);
        }
    }
}
