using GymAPI.Models;
using GymAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [ApiController]
    [Route("members/{memberId}/checkins")]
    public class CheckInController : ControllerBase
    {
        private static List<CheckIn> checkIns = CheckInRepository.LoadCheckIns();

        [HttpGet]
        public IActionResult GetCheckIns(int memberId)
        {
            var history = checkIns.Where(c => c.MemberId == memberId).ToList();
            return Ok(history);
        }


        [HttpPost]
        public IActionResult CheckIn(int memberId)
        {
            var checkIn = new CheckIn(memberId, DateTime.Now);

            checkIns.Add(checkIn);
            CheckInRepository.SaveCheckIns(checkIns);

            return CreatedAtAction(nameof(GetCheckIns), new { memberId = memberId }, checkIn);
        }
    }
}