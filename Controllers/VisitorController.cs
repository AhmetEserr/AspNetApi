using ApiWorking.DAL.Context;
using ApiWorking.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWorking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {

        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                // var values = context.Visitors.ToList(); 
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                    return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)

        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }

            }

        }
        [HttpPut]
        public IActionResult VisitorPut(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(visitor.VisitorId);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.VisitorId = visitor.VisitorId;
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.City= visitor.City;
                    values.Country= visitor.Country;
                    values.Mail= visitor.Mail;
                    context.Update(values);
                    context.SaveChanges();

                    return Ok();
                }
            }

        }
    }
    }
