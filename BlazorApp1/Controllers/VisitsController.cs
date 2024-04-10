


using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1.Controllers
{
    [ApiController]
    [Route("api/animals/{animalId}/[controller]")]
    public class VisitsController : ControllerBase
    {
        private static List<Visit> visits = new List<Visit>();

        [HttpGet]
        public ActionResult<List<Visit>> Get(int animalId)
        {
            return visits.Where(v => v.Animal.Id == animalId).ToList();
        }

        [HttpPost]
        public IActionResult Post(int animalId, [FromBody] Visit visit)
        {
            var animal = AnimalsController.animals.FirstOrDefault(a => a.Id == animalId);
            if (animal == null) return NotFound("Animal not found");

            visit.Animal = animal;
            visits.Add(visit);
            return CreatedAtAction(nameof(Get), new { animalId = animalId }, visit);
        }
    }
}

