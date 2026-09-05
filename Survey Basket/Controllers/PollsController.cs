

using System.Reflection;

namespace Survey_Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly Iservicespoll _iservicespoll;
        public PollsController(Iservicespoll iservicespoll)
        {
            _iservicespoll = iservicespoll;
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Poll> _polls = _iservicespoll.GetAll();

            return Ok(_polls);
        }


        [HttpPost]
        public IActionResult add(Poll model)
        {
            if (model is not null)
            {
                _iservicespoll.Add(model);
                return CreatedAtAction("Get", model.Id, model);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(int id, Poll model)
        {

            var is_sucseud = _iservicespoll.Update(id, model);
            if (is_sucseud)
                return NoContent();
            else
                return NotFound();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var is_sucseud = _iservicespoll.remove(id);
            if (is_sucseud)
                return NoContent();
            else
                return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var model=_iservicespoll.GetById(id);
            if(model == null)
                return NotFound();
            else
                return 
                    Ok(model);

        }
    }
}