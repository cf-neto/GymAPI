using GymAPI.Models;
using GymAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlansController : ControllerBase
    {
        private static List<Plan> plans = PlanRepository.LoadPlans();

        [HttpGet]
        public IActionResult GetAll() => Ok(plans);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var plan = plans.FirstOrDefault(p => p.Id == id);
            return plan is not null ? Ok(plan) : NotFound();
        }

        [HttpPost]
        public IActionResult Create(Plan plan)
        {
            plan.Id = plans.Count + 1;
            plans.Add(plan);
            PlanRepository.SavePlans(plans);
            return CreatedAtAction(nameof(GetById), new { id = plan.Id }, plan);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var plan = plans.FirstOrDefault(p => p.Id == id);
            if (plan is null) return NotFound();

            plans.Remove(plan);
            PlanRepository.SavePlans(plans);
            return Ok();
        }

    }
}