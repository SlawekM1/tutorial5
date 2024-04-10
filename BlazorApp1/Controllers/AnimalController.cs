

using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        public static List<Animal> animals = new List<Animal>();

        [HttpGet]
        public ActionResult<List<Animal>> Get() => animals;

        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();
            return animal;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            animals.Add(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Animal animal)
        {
            var index = animals.FindIndex(a => a.Id == id);
            if (index == -1) return NotFound();

            animals[index] = animal;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = animals.FindIndex(a => a.Id == id);
            if (index == -1) return NotFound();

            animals.RemoveAt(index);
            return NoContent();
        }
    }
}
