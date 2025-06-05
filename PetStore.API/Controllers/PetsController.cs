using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using PetStore.Data.Model;
using PetStore.Data.Repositoriy.Interface;
using PetStore.Model.Model;

namespace PetStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository petRepository;

        public PetsController(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetDTO>>> GetPets()
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
            });
            return Ok(pets);
        }


        // GET: api/Pets/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }*/

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(PetDTO petDTO)
        {
            try
            {
                var pet = new Pet()
                {
                    Name = petDTO.Name,
                    Description = petDTO.Description,
                    BirthDate = petDTO.BirthDate,
                    AnimalType = (PetKind)petDTO.AnimalType,
                    Sex = petDTO.Sex,
                };
                petRepository.Add(pet);
                petRepository.SaveChanges();
                return Ok(petDTO);
            }
            catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Pets/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        /*private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }*/
    }
}
