using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApointmentController : ControllerBase
    {
        private static List<Apointment> apointments = new List<Apointment>
            {
                new Apointment{
                    Id = 1,
                    Name="DHIMBJE KOKE",
                    CreatedAt=DateTime.Now,

                },
                new Apointment{ 
                    Id=2,
                    Name="Dhimbje barku",
                    CreatedAt=DateTime.Today,
                }

            };



        [HttpGet]
        public async Task<ActionResult<List<Apointment>>> Get()
        {


            return Ok(apointments);

        }
        [HttpGet ("{id}")]
        public  async Task<ActionResult<Apointment>> Get(int id) 
        {
            var apointment = apointments.Find(a => a.Id == id);
            if (apointment == null)
                return BadRequest("apointment not found");
            return Ok(apointment);
        }

        [HttpPost]
        public async Task<ActionResult<List<Apointment>>> AddApointment(Apointment apointment)
        {
            apointments.Add(apointment);
            return Ok(apointments);

        }

        [HttpPut]
        public async Task<ActionResult<List<Apointment>>> UpdateApointment(Apointment request) 
        {
            var apointment = apointments.Find(a => a.Id == request.Id);
            if (apointment == null)
                return BadRequest(" You cannot put this apointment");

            apointment.Id = request.Id;
            apointment.Name = request.Name;
            apointment.CreatedAt = request.CreatedAt;
            apointments.Add(apointment);

            return Ok(apointments);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Apointment>>> Delete(int id) 
        {
            var apointment = apointments.Find(a => a.Id == id);
            if (apointment == null)
                return BadRequest("Apointment cannot found");

            apointments.Remove(apointment);
            return Ok(apointments);
        }


    }
}
