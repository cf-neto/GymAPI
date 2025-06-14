using GymAPI.Models;
using GymAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private static List<Member> members = MemberRepository.LoadMembers();


        [HttpGet]
        public IActionResult GetAll() => Ok(members);

        #region GET_BY_ID /member/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {  
            var member = members.FirstOrDefault(m => m.Id == id);
            return member is not null ? Ok(member) : NotFound();
        }
        #endregion


        #region CREATE /member
        [HttpPost]
        public IActionResult Create(Member member)
        {
            var plans = PlanRepository.LoadPlans();

            if (!plans.Any(p => p.Id == member.PlanId))
            {
                return BadRequest($"Plan with ID {member.PlanId} does not exist.");
            }

            member.Id = members.Count + 1;
            members.Add(member);
            MemberRepository.SaveMembers(members);

            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }
        #endregion


        #region DELETE /members/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var member = members.FirstOrDefault(m => m.Id == id);
            if (member is null) return NotFound();

            members.Remove(member);
            MemberRepository.SaveMembers(members);
            return Ok();
        }
        #endregion

    }
}